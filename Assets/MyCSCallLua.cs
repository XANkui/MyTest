
using UnityEngine;
using XLua;
//Test 更新0227

public class MyCSCallLua : MonoBehaviour {
	
	private LuaEnv luaEnv;

	// Use this for initialization
	void Start () {

		luaEnv = new LuaEnv ();

		luaEnv.DoString ("require'CSCallLua'");

		IPerson p = luaEnv.Global.Get<IPerson> ("person");

		print ("person.name: " + p.name);

		print ("person.age: " + p.age);


		p.name = "Duck";

		luaEnv.DoString ("print(person.name)");
	}
	
	private void OnDestroy() {

		luaEnv.Dispose ();
	}

	[CSharpCallLua]
	interface IPerson{

		string name{ get ; set;}

		int age{ get ; set; }

		void Add (int a, int b);
	}
}
