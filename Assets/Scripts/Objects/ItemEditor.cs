//using UnityEngine;
//using UnityEditor;
//using System.Collections;
//using System.Collections.Generic;
//
//public class ItemEditor : EditorWindow {
//
//	public ItemList ItemList;
//	private int viewIndex = 1;
//
//	[MenuItem ("Window/Item Editor %#e")]
//	static void  Init () 
//	{
//		EditorWindow.GetWindow (typeof (ItemEditor));
//	}
//
//	void  OnEnable () {
//		if(EditorPrefs.HasKey("ObjectPath")) 
//		{
//			string objectPath = EditorPrefs.GetString("ObjectPath");
//			ItemList = AssetDatabase.LoadAssetAtPath (objectPath, typeof(ItemList)) as ItemList;
//		}
//
//	}
//
//	void  OnGUI () {
//		GUILayout.BeginHorizontal ();
//		GUILayout.Label ("Item Editor", EditorStyles.boldLabel);
//		if (ItemList != null) {
//			if (GUILayout.Button("Show Item List")) 
//			{
//				EditorUtility.FocusProjectWindow();
//				Selection.activeObject = ItemList;
//			}
//		}
//		if (GUILayout.Button("Open Item List")) 
//		{
//			OpenItemList();
//		}
//		if (GUILayout.Button("New Item List")) 
//		{
//			EditorUtility.FocusProjectWindow();
//			Selection.activeObject = ItemList;
//		}
//		GUILayout.EndHorizontal ();
//
//		if (ItemList == null) 
//		{
//			GUILayout.BeginHorizontal ();
//			GUILayout.Space(10);
//			if (GUILayout.Button("Create New Item List", GUILayout.ExpandWidth(false))) 
//			{
//				CreateNewItemList();
//			}
//			if (GUILayout.Button("Open Existing Item List", GUILayout.ExpandWidth(false))) 
//			{
//				OpenItemList();
//			}
//			GUILayout.EndHorizontal ();
//		}
//
//		GUILayout.Space(20);
//
//		if (ItemList != null) 
//		{
//			GUILayout.BeginHorizontal ();
//
//			GUILayout.Space(10);
//
//			if (GUILayout.Button("Prev", GUILayout.ExpandWidth(false))) 
//			{
//				if (viewIndex > 1)
//					viewIndex --;
//			}
//			GUILayout.Space(5);
//			if (GUILayout.Button("Next", GUILayout.ExpandWidth(false))) 
//			{
//				if (viewIndex < ItemList.itemList.Count) 
//				{
//					viewIndex ++;
//				}
//			}
//
//			GUILayout.Space(60);
//
//			if (GUILayout.Button("Add Item", GUILayout.ExpandWidth(false))) 
//			{
//				AddItem();
//			}
//			if (GUILayout.Button("Delete Item", GUILayout.ExpandWidth(false))) 
//			{
//				DeleteItem(viewIndex - 1);
//			}
//
//			GUILayout.EndHorizontal ();
//			if (ItemList.itemList == null)
//				Debug.Log("wtf");
//			if (ItemList.itemList.Count > 0) 
//			{
//				GUILayout.BeginHorizontal ();
//				viewIndex = Mathf.Clamp (EditorGUILayout.IntField ("Current Item", viewIndex, GUILayout.ExpandWidth(false)), 1, ItemList.itemList.Count);
//				//Mathf.Clamp (viewIndex, 1, inventoryItemList.itemList.Count);
//				EditorGUILayout.LabelField ("of   " +  ItemList.itemList.Count.ToString() + "  items", "", GUILayout.ExpandWidth(false));
//				GUILayout.EndHorizontal ();
//
//				ItemList.itemList[viewIndex-1].itemName = EditorGUILayout.TextField ("Item Name", ItemList.itemList[viewIndex-1].itemName as string);
//				ItemList.itemList[viewIndex-1].itemDescription = EditorGUILayout.TextField ("Item Description", ItemList.itemList[viewIndex-1].itemDescription as string);
//				ItemList.itemList[viewIndex-1].itemAction = EditorGUILayout.TextField ("Item Action", ItemList.itemList[viewIndex-1].itemAction as string);
//				ItemList.itemList[viewIndex-1].itemIcon = EditorGUILayout.ObjectField ("Item Icon", ItemList.itemList[viewIndex-1].itemIcon, typeof (Texture2D), false) as Texture2D;
//				ItemList.itemList[viewIndex-1].itemObject = EditorGUILayout.ObjectField ("Item Object", ItemList.itemList[viewIndex-1].itemObject, typeof (Rigidbody), false) as Rigidbody;
//
//				GUILayout.Space(10);
//
//				GUILayout.BeginHorizontal ();
//				ItemList.itemList[viewIndex-1].isEquipment = (bool)EditorGUILayout.Toggle("isEquipment", ItemList.itemList[viewIndex-1].isEquipment, GUILayout.ExpandWidth(false));
//				ItemList.itemList[viewIndex-1].isWeapon = (bool)EditorGUILayout.Toggle("isWeapon", ItemList.itemList[viewIndex-1].isWeapon,  GUILayout.ExpandWidth(false));
//				//inventoryItemList.itemList[viewIndex-1].isQuestItem = (bool)EditorGUILayout.Toggle("QuestItem", inventoryItemList.itemList[viewIndex-1].isQuestItem,  GUILayout.ExpandWidth(false));
//				GUILayout.EndHorizontal ();
//
//				GUILayout.Space(10);
//
//				GUILayout.BeginHorizontal ();
//				ItemList.itemList[viewIndex-1].isStackable = (bool)EditorGUILayout.Toggle("Stackable ", ItemList.itemList[viewIndex-1].isStackable , GUILayout.ExpandWidth(false));
//				ItemList.itemList[viewIndex-1].destroyOnUse = (bool)EditorGUILayout.Toggle("Destroy On Use", ItemList.itemList[viewIndex-1].destroyOnUse,  GUILayout.ExpandWidth(false));
//				ItemList.itemList[viewIndex-1].weight = EditorGUILayout.FloatField("Weight", ItemList.itemList[viewIndex-1].weight,  GUILayout.ExpandWidth(false));
//				GUILayout.EndHorizontal ();
//
//				GUILayout.Space(10);
//
//			} 
//			else 
//			{
//				GUILayout.Label ("This Inventory List is Empty.");
//			}
//		}
//		if (GUI.changed) 
//		{
//			EditorUtility.SetDirty(ItemList);
//		}
//	}
//
//	void CreateNewItemList () 
//	{
//		// There is no overwrite protection here!
//		// There is No "Are you sure you want to overwrite your existing object?" if it exists.
//		// This should probably get a string from the user to create a new name and pass it ...
//		viewIndex = 1;
//		ItemList = CreateItemList.Create();
//		if (ItemList) 
//		{
//			ItemList.itemList = new List<Item>();
//			string relPath = AssetDatabase.GetAssetPath(ItemList);
//			EditorPrefs.SetString("ObjectPath", relPath);
//		}
//	}
//
//	void OpenItemList () 
//	{
//		string absPath = EditorUtility.OpenFilePanel ("Select Item List", "", "");
//		if (absPath.StartsWith(Application.dataPath)) 
//		{
//			string relPath = absPath.Substring(Application.dataPath.Length - "Assets".Length);
//			ItemList = AssetDatabase.LoadAssetAtPath (relPath, typeof(ItemList)) as ItemList;
//			if (ItemList.itemList == null)
//				ItemList.itemList = new List<Item>();
//			if (ItemList) {
//				EditorPrefs.SetString("ObjectPath", relPath);
//			}
//		}
//	}
//
//	void AddItem () 
//	{
//		Item newItem = new Item();
//		newItem.itemName = "New Item";
//		ItemList.itemList.Add (newItem);
//		viewIndex = ItemList.itemList.Count;
//	}
//
//	void DeleteItem (int index) 
//	{
//		ItemList.itemList.RemoveAt (index);
//	}
//}