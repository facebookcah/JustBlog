using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.ViewModels.Category;
using FA.JustBlog.ViewModels.Comment;
using FA.JustBlog.ViewModels.Post;
using FA.JustBlog.ViewModels.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA.JustBlog.WebCRUD.App_Start
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
        //    CreateMap<CreatePostViewModel, Post>()
        //        .ForMember(des => des.Title, opt => opt.MapFrom(src => src.Title))
        //        .ForMember(des => des.Content, opt => opt.MapFrom(src => src.Content))
        //        .ReverseMap();
            CreateMap<Post, CreatePostViewModel>().ReverseMap();
            CreateMap<Category, CreateCategoryViewModel>().ReverseMap();
            CreateMap<Tag, CreateTagViewModel>().ReverseMap();
            CreateMap<Comment, CreateCommentViewAdminModel>().ReverseMap();
            //CreateMap<Post, PostViewModel>().ReverseMap();
            //CreateMap<Post, PostViewModel>()
            //    .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(des => des.Title, opt => opt.MapFrom(src => src.Title))
            //    .ForMember(des => des.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
            //    .ForMember(des => des.UpdatedOn, opt => opt.MapFrom(src => src.UpdatedOn))
            //    .ForMember(des => des.Status, opt => opt.MapFrom(src => src.Status))
            //    .ReverseMap();
            //CreateMap<IEnumerable<Post>, IEnumerable<PostViewModel>>().ReverseMap();
        }

    }
}