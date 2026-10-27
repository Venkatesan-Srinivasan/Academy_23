internal class Arithmetic {
   internal virtual int Operation (int a, int b) => a + b;
}
internal class SubArithmetic : Arithmetic { }

internal class DiffArithmetic : Arithmetic {
   internal override int Operation (int a, int b) => a - b;
}

internal class MulArithmetic : Arithmetic {
   internal override int Operation (int a, int b) => a * b;
}