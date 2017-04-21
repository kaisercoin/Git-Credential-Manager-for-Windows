﻿/**** Git Credential Manager for Windows ****
 *
 * Copyright (c) GitHub Corporation
 * All rights reserved.
 *
 * MIT License
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the """"Software""""), to deal
 * in the Software without restriction, including without limitation the rights to
 * use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
 * the Software, and to permit persons to whom the Software is furnished to do so,
 * subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
 * FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN
 * AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
 * WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE."
**/

using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace GitHub.Shared.Converters
{
    public class AspectRatioConverter: DoubleConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var valueString = value as string;

            if (valueString != null && valueString.Contains(':'))
            {
                var split = valueString.Split(new[] { ':' }, 2);

                if (split.Length == 2)
                {
                    double d1, d2;
                    var ci = CultureInfo.InvariantCulture;

                    if (double.TryParse(split[0], NumberStyles.Float, ci, out d1)
                        && double.TryParse(split[1], NumberStyles.Float, ci, out d2))
                    {
                        return d1 / d2;
                    }
                }
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}
