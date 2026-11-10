.assembly extern mscorlib { }
.assembly Test { }
.method static void Test(string[] args)
{
   .entrypoint
   ldstr "Hello"
   call void [mscorlib]System.Console::WriteLine(string)
   ret
}