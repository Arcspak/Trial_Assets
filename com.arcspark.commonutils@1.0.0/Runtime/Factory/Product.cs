using System;

namespace Arcspark.CommonUtils
{
    /// <summary>
    /// Product is the base class of product type in factory design pattern.
    /// </summary>
    public abstract class Product: IProduct
    {
        public Guid ProductGUID
        {
            get => productGUID;
        }

        protected Guid productGUID = Guid.NewGuid();
    }
}