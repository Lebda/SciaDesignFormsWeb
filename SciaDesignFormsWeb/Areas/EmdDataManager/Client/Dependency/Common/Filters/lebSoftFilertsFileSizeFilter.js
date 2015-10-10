angular.module("lebSoftFilertsApplicationModule")
    .filter("lebSoftFilertsFileSizeFilter", function ()
    {
        return function (value)
        {
            if (angular.isNumber(value))
            {
                if (value < 1000)
                {
                    return value; // B
                }
                else if (value < 100000)
                {
                    return value / 1000; // kB
                }
                else
                {
                    return value / 1000000; // MB
                }
            }
            else
            {
                return value;
            }
        };
    });