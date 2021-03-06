using UnityEngine;
using UnityEditor;
using System.Collections;

public class ChangeSwitchEventEditor : EventEditor {

	private SerializableGameEvent ge;
	public ChangeSwitchEventEditor() {
		this.ge =  ScriptableObject.CreateInstance<SerializableGameEvent>();
		ge.Name = this.EventName;
		ge.setParameter ("switch", "");
		ge.setParameter ("value", true);
	}
	
	public SerializableGameEvent Result { 
		get{ return ge; }
	}
	public string EventName {
		get{ return "ChangeSwitch"; }
	}
	public EventEditor clone(){
		return new ChangeSwitchEventEditor();
	}
	
	public void useEvent(SerializableGameEvent ge){
		this.ge = ge;
		this.ge.Name = this.EventName;
		if (ge.getParameter ("switch") == null)
			ge.setParameter ("switch", "");
		if (ge.getParameter ("value") == null)
			ge.setParameter ("value", true);
	}
	
	public void draw(){

		ge.setParameter("switch", EditorGUILayout.TextField("SwitchID", (string) ge.getParameter("switch")));
		ge.setParameter("value", ParamEditor.editorFor("Value", ge.getParameter("value")));
	}

	public void detachEvent(SerializableGameEvent ge)
    {
        if (ge.getParameter("switch") == "")
        {
            ge.removeParameter("switch");
            ge.removeParameter("value");
        }
    }
	
}