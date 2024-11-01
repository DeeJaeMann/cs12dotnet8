SectionTitle("Reading all environment variables for process");
IDictionary vars = GetEnvironmentVariables();
DictionaryToTable(vars);

SectionTitle("Reading all environment variables for machine");
IDictionary varsMachine = GetEnvironmentVariables(
    EnvironmentVariableTarget.Machine);
DictionaryToTable(varsMachine);

SectionTitle("Reading all environment variables for user");
IDictionary varsUser = GetEnvironmentVariables(
    EnvironmentVariableTarget.User);
DictionaryToTable(varsUser);

WriteLine();

string myComputer = "My username is %LOGNAME%. My CPU is %MACHTYPE%";

WriteLine(ExpandEnvironmentVariables(myComputer));

string passwordKey = "MY_PASSWORD";

SetEnvironmentVariable(passwordKey, "Pa$$w0rd");
string? password = GetEnvironmentVariable(passwordKey);
WriteLine($"{passwordKey}: {password}");

string secretKey = "MY_SECRET";
string? secret = GetEnvironmentVariable(secretKey,
    EnvironmentVariableTarget.Process);
WriteLine($"Process - {secretKey}: {secret}");

secret = GetEnvironmentVariable(secretKey,
    EnvironmentVariableTarget.Machine);
WriteLine($"Machine - {secretKey}: {secret}");

secret = GetEnvironmentVariable(secretKey,
    EnvironmentVariableTarget.User);
WriteLine($"User - {secretKey}: {secret}");    