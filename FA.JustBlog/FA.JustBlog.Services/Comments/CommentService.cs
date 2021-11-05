﻿using AutoMapper;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using FA.JustBlog.ViewModels.Comment;
using FA.JustBlog.ViewModels.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ResponseResult Create(CreateCommentViewAdminModel request)
        {
            try
            {
                var comment = Mapper.Map<Comment>(request);
                this.unitOfWork.CommentRespository.Add(comment);
                this.unitOfWork.SaveChanges();
                return new ResponseResult();
            }
            catch (Exception ex)
            {

                return new ResponseResult(ex.Message);
            }
        }

        public void Edit(Comment post)
        {
            this.unitOfWork.CommentRespository.Update(post);
            post.UpdatedOn = DateTime.Now;
            this.unitOfWork.SaveChanges();
        }

        public Comment Find(int id)
        {
            return this.unitOfWork.CommentRespository.Find(c=>c.Id==id).FirstOrDefault();
        }

        public Comment GoToEdit(int id)
        {
            return this.unitOfWork.CommentRespository.Find(c => c.Id == id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            var comment= this.unitOfWork.CommentRespository.Find(c => c.Id == id).FirstOrDefault();
            this.unitOfWork.CommentRespository.Delete(comment);
            this.unitOfWork.SaveChanges();
        }
        public IEnumerable<CommentViewAdmin> GetAllForAdmin()
        {
            var comments = this.unitOfWork.CommentRespository.GetAll();
            var commentViewModels = Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentViewAdmin>>(comments);

            return commentViewModels;
        }
    }
}
