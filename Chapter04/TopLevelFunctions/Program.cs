using static System.Console;

WriteLine("* Top-level functions example");

WhatsMyNamespace();

void WhatsMyNamespace()
{
    WriteLine("Namespace of Program class: {0}",
        arg0: typeof(Program).Namespace ?? "null");
}