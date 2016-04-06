using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(CarController)), CanEditMultipleObjects]
public class FRCarEditor : Editor {

	CarController carScript;

	
	public override void OnInspectorGUI () {
		DrawDefaultInspector();
		serializedObject.Update();

		carScript = (CarController)target;
		if(GUI.changed){
			EngineCurveInit();
		}
		
	}
	
	void EngineCurveInit (){
		
		if(carScript.totalGears <= 0){
			Debug.LogError("You are trying to set your vehicle gear to 0 or below! Why you trying to do this???");
			return;
		}
		
		carScript.gearSpeed = new float[carScript.totalGears];
		carScript.engineTorqueCurve = new AnimationCurve[carScript.totalGears];
		carScript.currentGear = 0;
		
		for(int i = 0; i < carScript.engineTorqueCurve.Length; i ++){
			carScript.engineTorqueCurve[i] = new AnimationCurve(new Keyframe(0, 1));
		}
		
		for(int i = 0; i < carScript.totalGears; i ++){
			
			carScript.gearSpeed[i] = Mathf.Lerp(0, carScript.maxspeed / 1.25f, ((float)i/(float)(carScript.totalGears - 0)));
			
			if(i != 0){
				carScript.engineTorqueCurve[i].MoveKey(0, new Keyframe(0, Mathf.Lerp (1, 0, (float)i / (float)carScript.totalGears)));
				carScript.engineTorqueCurve[i].AddKey(Mathf.Lerp(0, carScript.maxspeed / 1.25f, ((float)i/(float)(carScript.totalGears + 1))), 1f);
				carScript.engineTorqueCurve[i].AddKey(Mathf.Lerp (0, carScript.maxspeed, (float)(i+1) / (float)carScript.totalGears), 0);
				carScript.engineTorqueCurve[i].postWrapMode = WrapMode.Clamp;
			}else{
				carScript.engineTorqueCurve[i].MoveKey(0, new Keyframe(0, 1));
				carScript.engineTorqueCurve[i].AddKey(Mathf.Lerp(25, carScript.maxspeed / 1.25f, ((float)(i + 1) / (float)(carScript.totalGears))), 0f);
				carScript.engineTorqueCurve[i].AddKey(Mathf.Lerp (0, carScript.maxspeed, (float)(i + 1) / (float)carScript.totalGears), .75f);
				carScript.engineTorqueCurve[i].postWrapMode = WrapMode.Clamp;
			}
			
		}
		
	}
	
}
