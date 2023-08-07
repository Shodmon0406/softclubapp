using Domain.Dtos;

namespace Infrastructure.Interfaces;

public interface IPostService
{
    Task<List<GetPostDto>> GetPosts();
    Task<GetPostDto> GetPostById(int id);
    Task<GetPostDto> AddPost(AddPostDto addPost);
    Task<GetPostDto> UpdatePost(AddPostDto addPost);
    Task<bool> DeletePost(int id);
    Task<int> GetVotesById(int id);
}