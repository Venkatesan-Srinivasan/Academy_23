abstract class Arithmetics {
   internal abstract int Operations (int a, int b);
}

internal class SubArithmetics : Arithmetics {
   internal override int Operations (int a, int b) => a + b;
}

internal class DiffArithmetics : Arithmetics {
   internal override int Operations (int a, int b) => a - b;
}

internal class MulArithmetics : Arithmetics {
   internal override int Operations (int a, int b) => a * b;
}