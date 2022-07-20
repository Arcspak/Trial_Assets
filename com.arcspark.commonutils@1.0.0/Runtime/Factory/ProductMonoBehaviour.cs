using System;
using UnityEngine;

namespace Arcspark.CommonUtils
{
    /// <summary>
    /// ProductMonoBehaviour is the base class of product type in factory mode, which is designed for Unity GameObject.
    /// </summary>
    public class ProductMonoBehaviour : MonoBehaviour, IProduct
    {
        public Guid ProductGUID
        {
            get => productGUID;
        }

        protected Guid productGUID = Guid.NewGuid();
    }
}