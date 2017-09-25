

namespace csharp ThriftApp.Lib #×¢ÊÍ

struct AppResource {
	1:string AppCode;
	2:string Scope;
	3:string ResourceCode;
	
}

struct AppAgent{
	1:string AppCode;
	2:string Name;
	3:i32 Status;
	4:map<string,i32> UserDict;
}

service IAgent{
	list<AppAgent> getAll();

	AppAgent getByCode(1:string code);
}