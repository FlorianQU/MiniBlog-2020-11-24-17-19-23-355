using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Services
{
    public class ArticleService
    {
        private readonly IArticleStore articleStore;
        private readonly IUserStore userStore;

        public ArticleService(IArticleStore articleStore, IUserStore userStore)
        {
            this.articleStore = articleStore;
            this.userStore = userStore;
        }

        public void Create(Article article)
        {
            if (article.UserName != null)
            {
                if (!userStore.Users.Exists(_ => article.UserName == _.Name))
                {
                    userStore.Users.Add(new User(article.UserName));
                }

                articleStore.Articles.Add(article);
            }
        }

        public Article GetById(Guid id)
        {
            return articleStore.Articles.FirstOrDefault(article => article.Id == id);
        }
    }
}
