namespace DXWebApplication1.Models.EF {
    using System;
    using System.Data.Entity;

    public partial class DataClassesDataContext : DbContext {
        public DataClassesDataContext()
            : base("name=DocumentsConnectionString") {
        }

        public virtual DbSet<Doc> Docs { get; set; }
    }
}
