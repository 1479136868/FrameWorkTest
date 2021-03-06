using UnityEngine;
using System.Collections.Generic;
	
public static class UnityTool
{
	/// <summary>
	/// 附加GameObject
	/// </summary>
	/// <param name="ParentObj"></param>
	/// <param name="ChildObj"></param>
	/// <param name="Pos"></param>
	public static void Attach( GameObject ParentObj, GameObject ChildObj, Vector3 Pos )
	{
		ChildObj.transform.parent = ParentObj.transform;
		ChildObj.transform.localPosition = Pos;
	}

	/// <summary>
	/// 附加GameObject子物体
	/// </summary>
	/// <param name="ParentObj"></param>
	/// <param name="ChildObj"></param>
	/// <param name="RefPointName"></param>
	/// <param name="Pos"></param>
	public static void AttachToRefPos( GameObject ParentObj, GameObject ChildObj,string RefPointName,Vector3 Pos )
	{
		// Search 
		bool bFinded=false;
		Transform[] allChildren = ParentObj.transform.GetComponentsInChildren<Transform>();
		Transform RefTransform = null;
		foreach (Transform child in allChildren)
		{            
			if (child.name == RefPointName)
			{                
				if (bFinded == true)
				{
					Debug.LogWarning("物件["+ParentObj.transform.name+"]內有兩個以上的參考點["+RefPointName+"]");
					continue;
				}
				bFinded = true;
				RefTransform = child;
			}
		}
		
		//  是否找到
		if (bFinded == false)
		{
			Debug.LogWarning("物件["+ParentObj.transform.name+"]內沒有參考點["+RefPointName+"]");
			Attach( ParentObj,ChildObj,Pos);
			return ;
		}

		ChildObj.transform.parent = RefTransform;
		ChildObj.transform.localPosition = Pos;
		ChildObj.transform.localScale = Vector3.one;
		ChildObj.transform.localRotation = Quaternion.Euler( Vector3.zero);				
	}
	
	/// <summary>
	/// 查找游戏物体(全局找)
	/// </summary>
	/// <param name="GameObjectName">游戏物体名字</param>
	/// <returns></returns>
	public static GameObject FindGameObject(string GameObjectName)
	{ 
		GameObject pTmpGameObj = GameObject.Find(GameObjectName);
		if(pTmpGameObj==null)
		{
			Debug.LogWarning("景場中找不到GameObject["+GameObjectName+"]物件");
			return null;
		}
		return pTmpGameObj;
	}

	/// <summary>
	/// 查找子物体
	/// </summary>
	/// <param name="Container">在此层下找</param>
	/// <param name="gameobjectName">游戏物体名字</param>
	/// <returns></returns>
	public static GameObject FindChildGameObject(GameObject Container, string gameobjectName)
	{
		if (Container == null)
		{
			Debug.LogError("NGUICustomTools.GetChild : Container =null");
			return null;
		}
		
		Transform pGameObjectTF=null; //= Container.transform.FindChild(gameobjectName);											

				
		// 是不是Container本身
		if(Container.name == gameobjectName)			
			pGameObjectTF=Container.transform;
		else
		{	
			// 找出所有子元件						
			Transform[] allChildren = Container.transform.GetComponentsInChildren<Transform>();
			foreach (Transform child in allChildren)			
			{            
				if (child.name == gameobjectName)
				{
					if(pGameObjectTF==null)					
						pGameObjectTF=child;
					else
						Debug.LogWarning("Container["+Container.name+"]下找出重覆的元件名稱["+gameobjectName+"]");
				}
			}
		}
		
		// 都沒有找到
		if(pGameObjectTF==null)			
		{
			Debug.LogError("元件["+Container.name+"]找不到子元件["+gameobjectName+"]");		
			return null;
		}
		
		return pGameObjectTF.gameObject;			
	}
}
