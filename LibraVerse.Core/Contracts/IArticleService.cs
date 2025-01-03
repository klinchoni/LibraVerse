﻿namespace LibraVerse.Core.Contracts
{
    using LibraVerse.Core.Enums;

    using LibraVerse.Core.Models.QueryModels.Article;
    using LibraVerse.Core.Models.ViewModels.Article;
    using LibraVerse.Data.Models.Articles;

    public interface IArticleService
    {
        Task<bool> ArticleExistsAsync(int articleId);
        Task<Article> FindArticleByIdAsync(int articleId);
        Task<ArticleQueryServiceModel> AllAsync(
            string? searchTerm = null,
            ArticleSorting sorting = ArticleSorting.Newest,
            int currentPage = 1,
            int articlesPerPage = 4);
        Task<ArticleViewModel> DetailsAsync(int articleId);
        Task<ArticleCommentQueryServiceModel> AllArticleCommentsAsync(
            int articleId,
            string articleTitle,
            string? searchTerm = null,
            ArticleCommentSorting sorting = ArticleCommentSorting.Newest,
            int currentPage = 1,
            int articlesPerPage = 4);

        Task<int> AddArticleCommentAsync(ArticleCommentAddViewModel commentForm, string userId, int articleId);
        Task<ArticleComment> FindArticleCommentByIdAsync(int id);
        Task<ArticleCommentEditViewModel> EditArticleCommentGetAsync(int commentId);
        Task<int> EditArticleCommentPostAsync(ArticleCommentEditViewModel commentForm);
        Task<ArticleCommentDeleteViewModel> DeleteArticleCommentAsync(int commentId);
        Task<int> DeleteArticleCommentConfirmedAsync(int commentId);

    }
}