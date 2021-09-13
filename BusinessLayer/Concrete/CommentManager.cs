using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager
    {
        Repository<Comment> RepoComment = new Repository<Comment>();

        public List<Comment> GetCommentById(int id)
        {
            return RepoComment.List(x => x.BlogId == id);
        }
        public int CommentAdd(Comment p)
        {
            if(p.CommentText=="" || p.CommentText.Length>=301 || p.UserName=="" || p.Mail=="" || p.UserName.Length <= 2)
            {
                return -1;
            }
            return RepoComment.Insert(p);
        }

        public List<Comment> CommentList()
        {
            return RepoComment.List();
        }

        //Statüs değeri True olan yorumların listelenmesi
        public List<Comment> commentByStatusTrue()
        {
            return RepoComment.List(x => x.CommentStatus == true);
        }

        //Statüs değeri False olan yorumların listelenmesi
        public List<Comment> commentByStatusFalse()
        {
            return RepoComment.List(x => x.CommentStatus == false);
        }

        //yorumun status değerini false yapma
        public int CommentStatusChangeToFalse(int id)
        {
            Comment comment = RepoComment.Find(x => x.CommentId == id);
            comment.CommentStatus = false;
            return RepoComment.Update(comment);
        }

        //Yorumun Status değerini True Yapma

        public int CommentStatusChangeToTrue(int id)
        {
            Comment comment = RepoComment.Find(x => x.CommentId == id);
            comment.CommentStatus = true;
            return RepoComment.Update(comment);
        }
    }
}
 