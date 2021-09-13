using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorManager
    {
        Repository<Author> repoAuthor = new Repository<Author>();

        //Tüm yazar listesini getirme
        public List<Author> GetAll()
        {
            return repoAuthor.List();
        }

        //Yeni yazar ekleme işlemi
        public int AddAuthorBL(Author author)
        {
            //Parametreden gönderilen değerlerin geçerliliğinin kontrolü
            if (author.AuthorName == "" || author.AuthorAbout == "" || author.AuthorTitle == "" || author.AboutShort == "")
            {
                return -1;
            }
            return repoAuthor.Insert(author);
        }

        //Yazarı id değerine göre edit sayfasına taşıma
        public Author FindAuthor(int id)
        {
            return repoAuthor.Find(x => x.AuthorId == id);
        }

        public int EditAuthor(Author p)
        {
            Author author = repoAuthor.Find(x => x.AuthorId == p.AuthorId);
            author.AboutShort = p.AboutShort;
            author.AuthorName = p.AuthorName;
            author.AuthorImage = p.AuthorImage;
            author.AuthorAbout = p.AuthorAbout;
            author.AuthorTitle = p.AuthorTitle;
            author.Mail = p.Mail;
            author.Password = p.Password;
            author.PhoneNumber = p.PhoneNumber;
            return repoAuthor.Update(author);
        }
    }
}
