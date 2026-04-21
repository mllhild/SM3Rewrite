using System;
using System.Collections.Generic;
using System.Linq;

namespace SM3Rewrite
{
    public class SizeToSize
    {
        private List<float> sizes;

        public SizeToSize(float[] limits = null)
        {
            if (limits == null)
                limits = new float[] { 10, 20, 30, 40, 50 };

            sizes = limits.ToList();

            // Safety: ensure correct length
            if (sizes.Count != Enum.GetValues(typeof(Size)).Length - 1)
                throw new ArgumentException("Limits must be one less than enum count.");
        }

        public Size GetSizeFromNumber(float value)
        {
            for (int i = 0; i < sizes.Count; i++)
            {
                if (value < sizes[i])
                    return (Size)i;
            }

            return Size.gigantic; // last category
        }
    }
}
