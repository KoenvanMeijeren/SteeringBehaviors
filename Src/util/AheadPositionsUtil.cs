using System;

namespace Src.util
{
    public static class AheadPositionsUtil
    {
        public static Tuple<Vector, Vector, Vector> Generate(Vector vector, bool isDirectionRight, bool isDirectionUpwards, bool isDirectionDownwards)
        {
            Vector vectorDiagonalUpper;
            Vector vectorDiagonalLower;
            if (isDirectionRight)
            {
                if (isDirectionDownwards)
                {
                    vectorDiagonalUpper = (new Vector(vector.X - 32, vector.Y + 32));
                    vectorDiagonalLower = (new Vector(vector.X + 32, vector.Y + 32));

                    return new Tuple<Vector, Vector, Vector>(vector, vectorDiagonalUpper, vectorDiagonalLower);
                }

                vectorDiagonalUpper = (new Vector(vector.X + 32, vector.Y - 32));
                vectorDiagonalLower = (new Vector(vector.X + 32, vector.Y + 32));

                return new Tuple<Vector, Vector, Vector>(vector, vectorDiagonalUpper, vectorDiagonalLower);
            }

            if (isDirectionDownwards)
            {
                vectorDiagonalUpper = (new Vector(vector.X + 32, vector.Y + 32));
                vectorDiagonalLower = (new Vector(vector.X - 32, vector.Y + 32));

                return new Tuple<Vector, Vector, Vector>(vector, vectorDiagonalUpper, vectorDiagonalLower);
            }

            if (isDirectionUpwards)
            {
                vectorDiagonalUpper = (new Vector(vector.X + 32, vector.Y - 32));
                vectorDiagonalLower = (new Vector(vector.X - 32, vector.Y - 32));

                return new Tuple<Vector, Vector, Vector>(vector, vectorDiagonalUpper, vectorDiagonalLower);
            }

            vectorDiagonalUpper = (new Vector(vector.X - 32, vector.Y - 32));
            vectorDiagonalLower = (new Vector(vector.X - 32, vector.Y + 32));

            return new Tuple<Vector, Vector, Vector>(vector, vectorDiagonalUpper, vectorDiagonalLower);
        }
    }
}
