using System.Linq.Expressions;

namespace OnlineEdu.DataAccess.Abstract;
public interface IRepository<T> where T : class
{
    List<T> GetList();
    List<T> GetFilteredList(Expression<Func<T, bool>> predicate);

    T GetById(int id);
    T GetByFilter(Expression<Func<T, bool>> predicate);

    void Create(T entity);
    void Update(T entity);
    void Delete(int id);

    int Count();

    int FilteredCount(Expression<Func<T, bool>> predicate);
    
}