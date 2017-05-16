using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Storage data manager.
/// </summary>
namespace StorageManager
{
		//storage root object
		[System.Serializable]
		public class StagesDataRoot
		{
				public List<StagePart> stagesParts;

				public StagesDataRoot ()
				{
						stagesParts = new List<StagePart> ();
				}
		}

		//used for storage(read/write) 'not' like stage element component
		[System.Serializable]
		public class StagePart
		{
				public bool isLocked = false;// is the stage element ( part ) is locked
				public int id = 0;//stage element (part) id
				public int starLevel = 0;//star level (one:1 ,two:2 , three:3)
		}

		//storage helper class
		public class StagesStorageHelper
		{
				public static StagesDataRoot stagesDataRoot;
				private const string fileName = "stagedata.bin";
				private const int maxCount = 15;

				//get default element data
				public static List<StagePart> GetDefaultElementsData ()
				{
						List<StagePart> stageElements = new List<StagePart> ();
						StagePart part;
						for (int i = 0; i  <maxCount; i++) {
								part = new StagePart ();
								if (i != 0) {
										part.isLocked = true;
								}

								part.id = (i + 1);
								stageElements.Add (part);

						}
						return stageElements;
				}

				//get stage current element data
				public static List<StagePart> GetStageCurrentElementsData ()
				{
						GameObject [] stagesObjects = GameObject.FindGameObjectsWithTag ("StageElement");

						if (stagesObjects == null) {
								return GetDefaultElementsData ();
						} else if (stagesObjects.Length == 0) {
								return GetDefaultElementsData ();
						}

						List<StagePart> stageElements = new List<StagePart> ();

						int count = stagesObjects.Length;
						StageElement sp;
						StagePart part;
						for (int i = 0; i < count; i++) {

								sp = stagesObjects [i].GetComponent<StageElement> ();

								if (sp == null) {
										Debug.LogError ("Null StageElement Component");
										continue;
								}

								part = new StagePart ();
								part.id = sp.id;
								part.starLevel = sp.starLevel;
								part.isLocked = sp.isLocked;
								stageElements.Add (part);
						}
						return stageElements;
				}

				//apply data to stage elements in the scene
				public static void ApplyDataToStageElementsInScene (List<StagePart> stageElements)
				{
						if (stageElements == null) {
								return;
						}

						GameObject [] stagesObjects = GameObject.FindGameObjectsWithTag ("StageElement");
					
						StageElement obStageElementComp;
						GameObject starLevelOb = null, lockOb = null, levelNumberOb = null;
						Transform contentTransform;
						GameObject tempOb;
						int childCount = 0;

						foreach (StagePart sp in stageElements) {
				          
								obStageElementComp = GetStageElementById (sp.id, stagesObjects); 
								contentTransform = obStageElementComp.transform.Find ("content");
								childCount = contentTransform.childCount;

								for (int i = 0; i < childCount; i++) {
										tempOb = contentTransform.GetChild (i).gameObject;
										if (tempOb.name == "lock") {
												lockOb = tempOb;
										} else if (tempOb.name == "level_number(s)") {
												levelNumberOb = tempOb;
										} else if (tempOb.name == "star_level") {
												starLevelOb = tempOb;
										}
								}
							
								obStageElementComp.isLocked = sp.isLocked;
								obStageElementComp.starLevel = sp.starLevel;

								if (sp.isLocked) {
										lockOb.SetActive (true);
										levelNumberOb.SetActive (false);
										starLevelOb.SetActive (false);
								} else {
										lockOb.SetActive (false);
										levelNumberOb.SetActive (true);
										starLevelOb.SetActive (true);
										obStageElementComp.SetBackgoundIcon (1, obStageElementComp.GetComponent<SpriteRenderer> ());
										obStageElementComp.SetStarsLevel (sp.starLevel, starLevelOb.GetComponent<SpriteRenderer> ());
								}
						}
						Debug.Log ("Data has been applied to StageElements in the Scene at " + Time.time);
				}

				//get stage part by id
				public static StagePart GetStagePartById (int id, List<StagePart> stagesParts)
				{
						if (stagesParts == null) {
								return null;
						}

						foreach (StagePart sp in stagesParts) {

								if (id == sp.id) {
										return sp;
								}
						}
						return null;
				}

				//get(find) stage element by id
				public static StageElement GetStageElementById (int id, GameObject[] stagesObjects)
				{
						if (stagesObjects == null) {
								return null;
						}

						StageElement se = null;
						foreach (GameObject ob in stagesObjects) {
								se = ob.GetComponent<StageElement> ();
								if (se == null) {
										Debug.LogError ("Null StageElement Component");
										return null;
								}
								if (id == se.id) {
										return se;
								}
						}
						return se;
				}

				//wirte stages data
				public static void WriteStagesData (StagesDataRoot root)
				{
						string path = FileManager.getPlatformPath () + fileName;
						FileManager.WriteToBinaryFile (path, root);
						Debug.Log ("Stages Data has been written at " + Time.time);
				}

				//Read stages data
				public static StagesDataRoot ReadStagesData ()
				{
						StagesDataRoot root = null;
						string path = FileManager.getPlatformPath () + fileName;
						if (!FileManager.IsFileExists (path)) {
								root = new StagesDataRoot ();
								root.stagesParts = GetStageCurrentElementsData ();
								WriteStagesData (root);
						} else {
								root = (StagesDataRoot)FileManager.ReadFromBinaryFile<StagesDataRoot> (path);
								if (FileManager.isException) {
										WriteStagesData (root);
								}
								Debug.Log ("Stages Data has been readed at " + Time.time);
						}
						
						return root;
				}

				public static int MaxElementsCount {
						get{ return maxCount;}
				}

		}
}