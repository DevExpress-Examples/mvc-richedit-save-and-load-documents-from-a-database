namespace DXWebApplication1.Models.EF {
    using System;

    public partial class Doc {
        public Guid Id { get; set; }
        public byte[] DocBytes { get; set; }
        public string Comment { get; set; }
    }
}
