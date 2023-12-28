namespace Day24
{
    public class HailStone
    {
        public HailStone(string line)
        {
            var parts = line.Split('@');
            var positionParts = parts[0].Split(',');
            var velocityParts = parts[1].Split(',');

            Position = new Vector(float.Parse(positionParts[0].Trim()), float.Parse(positionParts[1].Trim()), float.Parse(positionParts[2].Trim()));
            Velocity = new Vector(float.Parse(velocityParts[0].Trim()), float.Parse(velocityParts[1].Trim()), float.Parse(velocityParts[2].Trim()));
        }

        public Vector Position { get; }

        public Vector Velocity { get; }

        protected float Slope2D() => (float)Velocity.Y / (float)Velocity.X;

        public bool WillCollide2D(HailStone other, long minTest, long maxTest)
        {
            var slope = Slope2D();
            var otherSlope = other.Slope2D();

            if (slope == otherSlope)
            {
                return false;  //parallel case
            }

            var commonX = ((otherSlope * other.Position.X) - (slope * Position.X) + Position.Y - other.Position.Y) / (otherSlope - slope);
            if (commonX < minTest || commonX > maxTest) return false;

            var commonY = (slope * (commonX - Position.X)) + Position.Y;
            if (commonY < minTest || commonY > maxTest) return false;

            return IsInFuture(new Vector(commonX, commonY, 0)) && other.IsInFuture(new Vector(commonX, commonY, 0));
        }

        public bool IsInFuture(Vector position)
        {
            if (Velocity.X < 0 && Position.X < position.X)
            {
                return false;
            }
            if (Velocity.X > 0 && Position.X > position.X)
            {
                return false;
            }
            if (Velocity.Y < 0 && Position.Y < position.Y)
            {
                return false;
            }
            if (Velocity.Y > 0 && Position.Y > position.Y)
            {
                return false;
            }

            return true;
        }
    }
}