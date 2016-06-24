using System;
using System.Collections.Generic;

namespace RectangleProject
{
    public class Rectangle
    {
        private double _a;
        private double _b;
        private double _c;

        private readonly double _square;
        public double Square
        {
            get
            {
                return _square;
            }
        }

        private readonly bool _isRectangle;
        public bool IsRectangle
        {
            get
            {
                return _isRectangle;
            }
        }
        public Rectangle(double a, double b, double c)
        {
            if (a < 0)
                throw new ArgumentException("Длина первой стороны не может быть меньше 0", "a");
            if (b < 0)
                throw new ArgumentException("Длина второй стороны не может быть меньше 0", "b");
            if (c < 0)
                throw new ArgumentException("Длина третьей стороны не может быть меньше 0", "c");

            _a = a;
            _b = b;
            _c = c;

            if (a == 0 || b == 0 || c == 0)
            {
                _isRectangle = false;
                _square = 0;
                return;
            }

            var maxLine = GetMaximumLine(a, b, c);
            _isRectangle = FigureIsRectangle(a, b, c, maxLine);
            if (_isRectangle)
                _square = GetSquare(a, b, c, maxLine);
        }

        private static bool FigureIsRectangle(double a, double b, double c, string maxLine)
        {
            var eps = 0.00000001;
            switch (maxLine)
            {
                case "no":
                    return false;
                case "a":
                    return IsRectangleProper(a, b, c, eps);
                case "b":
                    return IsRectangleProper(b, a, c, eps);
                case "c":
                    return IsRectangleProper(c, a, b, eps);
            }
            throw new KeyNotFoundException("Произошла ошибка при определении самой длинной стороны.");
        }

        private static string GetMaximumLine(double a, double b, double c)
        {
            if (a > b && a > c)
                return "a";
            if (b > a && b > c)
                return "b";
            if (c > a && c > b)
                return "c";
            return "no";
        }

        private static bool IsRectangleProper(double gip, double a, double b, double eps)
        {
            return Math.Abs(
                Math.Round(
                    Math.Pow(
                        gip,
                        2),
                    10,
                    MidpointRounding.AwayFromZero) -
                (Math.Round(
                    Math.Pow(
                        a,
                        2),
                    10,
                    MidpointRounding.AwayFromZero) +
                Math.Round(
                    Math.Pow(
                        b,
                        2),
                    10,
                    MidpointRounding.AwayFromZero)))
                   < eps;
        }

        private double GetSquare(double a, double b, double c, string maxLine)
        {
            switch (maxLine)
            {
                case "no":
                    return 0;
                case "a":
                    return CountSquare(b, c);
                case "b":
                    return CountSquare(a, c);
                case "c":
                    return CountSquare(a, b);
            }
            throw new KeyNotFoundException("Произошла ошибка при определении самой длинной стороны.");
        }

        private double CountSquare(double a, double b)
        {
            return Math.Round(0.5*a*b, 10, MidpointRounding.AwayFromZero);
        }
    }
}
