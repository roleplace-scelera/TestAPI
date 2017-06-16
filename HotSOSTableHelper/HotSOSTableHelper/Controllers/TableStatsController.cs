using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;

/*
The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using Models;
ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
builder.EntitySet<Table1>("Table1");
config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
*/
public class TableStatsController : ApiController
{
    private HotSOS_TablesStatsContext db = new HotSOS_TablesStatsContext();

    // GET: odata/Table1
    public IQueryable<TableStats> GetCollectionTableStats()
    {
        return db.TableStatsCollection;
    }

    // GET: odata/Table1(5)
    [ResponseType(typeof(TableStats))]
    public async Task<IHttpActionResult> GetTableStats(string key)
    {
        TableStats table = await db.TableStatsCollection.FindAsync(key);
        if (table == null)
        {
            return NotFound();
        }
        return Ok(table);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            db.Dispose();
        }
        base.Dispose(disposing);
    }

    private bool TableStatsExists(string key)
    {
        return db.TableStatsCollection.Count(e => e.Name == key) > 0;
    }
}

