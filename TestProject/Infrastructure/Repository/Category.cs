using TestProject.Infrastructure.IRepository;
using TestProject.Models;
using System.Data;
using Dapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TestProject.Infrastructure.Repository
{
    public class Category : ICategory

    {
        private readonly IDapperServices _dapper;

        public Category(IDapperServices dapper)
        {
            _dapper = dapper;
        }

        public CategoryInfo AddCategory(CategoryInfo categoryInfo)
        {
            CategoryInfo model = new CategoryInfo();
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("Category_Id", categoryInfo.Category_Id);
                dbPara.Add("CategoryTitle", categoryInfo.CategoryTitle);
                dbPara.Add("GroupName", categoryInfo.GroupName);
                dbPara.Add("CategoryStatus", categoryInfo.CategoryStatus);
                model.TotalRowCount = Task.FromResult(_dapper.ExecuteScaler<CategoryInfo>("CategoryAddEdit", dbPara, commandType: CommandType.StoredProcedure)).Result;
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }

        public CategoryInfo DeleteCategory(CategoryInfo infomodel)
        {
            CategoryInfo model = new CategoryInfo();
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@Category_Id",infomodel.Category_Id);
                model.TotalRowCount = Task.FromResult(_dapper.ExecuteScaler<CategoryInfo>("CategoryDelete", dbPara, commandType: CommandType.StoredProcedure)).Result;
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }

        public CategoryInfo GetCategoryById(int id)
        {
            var query = @"select * from Category where Category_Id=@Category_Id";
            CategoryInfo categoryInfo = new CategoryInfo();
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("Category_Id", id);
                categoryInfo = Task.FromResult(_dapper.Get<CategoryInfo>(query, dbPara,commandType: CommandType.Text)).Result;
            }
            catch (Exception)
            {
                throw;
            }
            return categoryInfo;    
        }

        public List<CategoryInfo> GetCategoryData()
        {
            var query = @"Select * from Category";
            List<CategoryInfo> categories = new List<CategoryInfo>();
            try
            {
                categories=Task.FromResult(_dapper.GetAll<CategoryInfo>(query,null,commandType:CommandType.Text)).Result;
            }
            catch (Exception)
            {
                throw;
            }
            return categories;
        }

        public CategoryInfo UpdateCategory(CategoryInfo categoryInfo)
        {
            throw new NotImplementedException();
        }

        /* public CategoryInfo UpdateCategory(CategoryInfo categoryInfo)
         {
             CategoryInfo model = new CategoryInfo();
             try
             {
                 var dbPara = new DynamicParameters();
                 dbPara.Add("Category_Id", categoryInfo.Category_Id);
                 dbPara.Add("CategoryTitle", categoryInfo.CategoryTitle);
                 dbPara.Add("GroupName", categoryInfo.GroupName);
                 dbPara.Add("CategoryStatus", categoryInfo.CategoryStatus);
                 categoryInfo.TotalRowCount = Task.FromResult(_dapper.ExecuteScaler<CategoryInfo>("CategoryAddEdit", dbPara, commandType: CommandType.StoredProcedure)).Result;
             }
             catch (Exception)
             {
                 throw;
             }
             return model;
         }*/
    }
}
