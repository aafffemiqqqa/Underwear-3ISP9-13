//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShapPul.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Options
    {
        public int id { get; set; }
        public int IdColor { get; set; }
        public int IdSize { get; set; }
        public int IdModel { get; set; }
        public int IdProduct { get; set; }
    
        public virtual Color Color { get; set; }
        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
    }
}
