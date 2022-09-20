using System;

namespace testapp
{
    // This class is never actually executed, but when Xamarin linking is enabled it does ensure types and properties
    // are preserved in the deployed app
    [Foundation.Preserve(AllMembers = true)]
    public class LinkerPleaseInclude
    {
        public void Include(IEntity c)
        {
            c = new ProductImage();
            c.Id = Guid.NewGuid();
        }

        public void Include(ProductImage p)
        {
            p.Id = Guid.NewGuid();
            p.ProductNumber = "sdf";
        }
    }
}
