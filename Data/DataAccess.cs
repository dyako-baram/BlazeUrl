using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.Sqlite;

namespace BlazeUrl.Data;
public static class DataAccess
{
    public static async Task<IEnumerable<UrlModel>> GetAllAsync()
    {
        using(var con =new SqliteConnection("data source=MyDb.db"))
        {
            return await con.QueryAsync<UrlModel>("select * from urls");

        }
    }
    public static async Task<string> GetByShort(string url)
    {
        using(var con =new SqliteConnection("data source=MyDb.db"))
        {
            return await con.ExecuteScalarAsync<string>("select Long from Urls where short=@shortUrl",new{shortUrl=url});

        }
    }
    public static void InsertRecord(UrlModel model)
    {
        using(var con =new SqliteConnection("data source=MyDb.db"))
        {
            con.Execute("insert into urls(short,long) values(@shortUrl,@longUrl)",new {@shortUrl=model.Short,longUrl=model.Long});
        }
    }
    public static async Task DeleteRecord(string key)
    {
        using(var con=new SqliteConnection("data source=MyDb.db"))
        {
            await con.ExecuteAsync("delete from Urls where short=@shortUrl",new {shortUrl=key});
        }
    }

}