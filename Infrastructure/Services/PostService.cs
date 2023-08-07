using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class PostService : IPostService
{
    private DataContext _context;

    public PostService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<GetPostDto>> GetPosts()
    {
        return await _context.Posts.Select(p => new GetPostDto()
        {
            Id = p.Id,
            Title = p.Title,
            Description = p.Description,
            Vote = p.Vote,
            CreatedAt = p.CreatedAt
        }).ToListAsync();
    }

    public async Task<GetPostDto> GetPostById(int id)
    {
        return await _context.Posts.Select(p => new GetPostDto()
        {
            Id = p.Id,
            Title = p.Title,
            Description = p.Description,
            Vote = p.Vote,
            CreatedAt = p.CreatedAt
        }).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<GetPostDto> AddPost(AddPostDto addPost)
    {
        var post = new Post()
        {
            Id = addPost.Id,
            Title = addPost.Title,
            Description = addPost.Description,
            Vote = addPost.Vote,
            CreatedAt = addPost.CreatedAt
        };
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
        return new GetPostDto()
        {
            Id = post.Id,
            Title = post.Title,
            Description = post.Description,
            Vote = post.Vote,
            CreatedAt = post.CreatedAt
        };
    }

    public async Task<GetPostDto> UpdatePost(AddPostDto addPost)
    {
        var post = new Post()
        {
            Id = addPost.Id,
            Title = addPost.Title,
            Description = addPost.Description,
            Vote = addPost.Vote,
            CreatedAt = addPost.CreatedAt
        };
        _context.Posts.Update(post);
        await _context.SaveChangesAsync();
        return new GetPostDto()
        {
            Id = post.Id,
            Title = post.Title,
            Description = post.Description,
            Vote = post.Vote,
            CreatedAt = post.CreatedAt
        };
    }

    public async Task<bool> DeletePost(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null) return false;
        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<int> GetVotesById(int id)
    {
        var vote = await _context.Posts.Select(p => new GetPostDto()
        {
            Id = p.Id,
            Title = p.Title,
            Description = p.Description,
            Vote = p.Vote,
            CreatedAt = p.CreatedAt
        }).FirstOrDefaultAsync(p => p.Id == id);
        return vote?.Vote ?? 0;
    }
}