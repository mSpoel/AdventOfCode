using Microsoft.Z3;

namespace Day24
{
    internal class SolverPart2
    {
        internal long GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            HailStone[] stones = new HailStone[lines.Length];

            int lineIndex = 0;
            foreach (var line in lines)
            {
                stones[lineIndex++] = new HailStone(line);
            }

            return Solver(stones);
        }

        private long Solver(HailStone[] stones)
        {
            //Kudos t
            var ctx = new Context();
            var solver = ctx.MkSolver();

            // Coordinates of the stone
            var x = ctx.MkIntConst("x");
            var y = ctx.MkIntConst("y");
            var z = ctx.MkIntConst("z");

            // Velocity of the stone
            var vx = ctx.MkIntConst("vx");
            var vy = ctx.MkIntConst("vy");
            var vz = ctx.MkIntConst("vz");

            // For each iteration, we will add 3 new equations and one new condition to the solver.
            // We want to find 9 variables (x, y, z, vx, vy, vz, t0, t1, t2) that satisfy all the equations, so a system of 9 equations is enough.
            for (var i = 0; i < 3; i++)
            {
                var t = ctx.MkIntConst($"t{i}"); // time for the stone to reach the hail
                var hail = stones[i];

                var px = ctx.MkInt(Convert.ToInt64(hail.Position.X));
                var py = ctx.MkInt(Convert.ToInt64(hail.Position.Y));
                var pz = ctx.MkInt(Convert.ToInt64(hail.Position.Z));

                var pvx = ctx.MkInt(Convert.ToInt64(hail.Velocity.X));
                var pvy = ctx.MkInt(Convert.ToInt64(hail.Velocity.Y));
                var pvz = ctx.MkInt(Convert.ToInt64(hail.Velocity.Z));

                var xLeft = ctx.MkAdd(x, ctx.MkMul(t, vx)); // x + t * vx
                var yLeft = ctx.MkAdd(y, ctx.MkMul(t, vy)); // y + t * vy
                var zLeft = ctx.MkAdd(z, ctx.MkMul(t, vz)); // z + t * vz

                var xRight = ctx.MkAdd(px, ctx.MkMul(t, pvx)); // px + t * pvx
                var yRight = ctx.MkAdd(py, ctx.MkMul(t, pvy)); // py + t * pvy
                var zRight = ctx.MkAdd(pz, ctx.MkMul(t, pvz)); // pz + t * pvz

                solver.Add(t >= 0); // time should always be positive - we don't want solutions for negative time
                solver.Add(ctx.MkEq(xLeft, xRight)); // x + t * vx = px + t * pvx
                solver.Add(ctx.MkEq(yLeft, yRight)); // y + t * vy = py + t * pvy
                solver.Add(ctx.MkEq(zLeft, zRight)); // z + t * vz = pz + t * pvz
            }

            solver.Check();
            var model = solver.Model;

            var rx = model.Eval(x);
            var ry = model.Eval(y);
            var rz = model.Eval(z);

            return Convert.ToInt64(rx.ToString()) + Convert.ToInt64(ry.ToString()) + Convert.ToInt64(rz.ToString());
        }
    }
}
