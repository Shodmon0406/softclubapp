using Domain.Dtos;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class PostController
{
    private IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet("get-posts")]
    public async Task<List<GetPostDto>> GetPosts()
    {
        return await _postService.GetPosts();
    }

    [HttpGet("get-post-by-id")]
    public async Task<GetPostDto> GetPostById(int id)
    {
        return await _postService.GetPostById(id);
    }

    [HttpPost("add-post")]
    public async Task<GetPostDto> AddPost([FromForm]AddPostDto addPost)
    {
        return await _postService.AddPost(addPost);
    }

    [HttpPut("update-post")]
    public async Task<GetPostDto> UpdatePost([FromForm]AddPostDto addPost)
    {
        return await _postService.UpdatePost(addPost);
    }

    [HttpDelete("delete-post")]
    public async Task<bool> DeletePost(int id)
    {
        return await _postService.DeletePost(id);
    }

    [HttpGet("get-votes")]
    public async Task<int> GetVote(int id)
    {
        return await _postService.GetVotesById(id);
    }
}