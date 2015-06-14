using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace IsartPolarium
{
	public class SceneManager
	{
		public GraphicsDeviceManager graphics;
		public ContentManager content;
		public SpriteBatch spriteBatch;

		Dictionary<int, AScene> _DScenes;
		Dictionary<int, AScene> _DScenesToAdd;
		List<int> _LScenesToRemove;

		//Scene
		public Level1 lvl1;
		public Level2 lvl2;
		public Level3 lvl3;
		public Level4 lvl4;
		//public Level5 lvl5;
		//public Level6 lvl6;
		//public Level7 lvl7;
		//public Level8 lvl8;
		//public MainMenu mMenu;
		//public MainMenu mMenu;
		public InGameInterface igInterface;

		public SceneManager (GraphicsDeviceManager _GDM, ContentManager _CM, SpriteBatch _SB)
		{
			graphics = _GDM;
			content = _CM;
			spriteBatch = _SB;
		}

		public void Initialize()
		{
			_DScenes = new Dictionary<int, AScene> ();
			_DScenesToAdd = new Dictionary<int, AScene> ();
			_LScenesToRemove = new List<int> ();
			graphics.PreferredBackBufferWidth = 1200/2;  // set this value to the desired width of your window
			graphics.PreferredBackBufferHeight = 1920/2;   // set this value to the desired height of your window

			//graphics.PreferredBackBufferWidth = 1280;  // set this value to the desired width of your window
			//graphics.PreferredBackBufferHeight = 720;   // set this value to the desired height of your window
			graphics.ApplyChanges();
		}

		public void LoadContent()
		{
			//Level 1
			//lvl1 = new Level1 (this);
			//AddScene (lvl1, 0);

			//Level 2
			//Level2 lvl2 = new Level2 (this);
			//AddScene (lvl2, 1);

			//Level 3
			//lvl3 = new Level3 (this);
			//AddScene (lvl3, 2);

			//lvl3.sceneState = SceneState.SLEEP;

			//Level 4
			//lvl4 = new Level4 (this);
			//AddScene (lvl4, 3);

			//lvl5 = new Level5 (this);
			//AddScene (lvl5, 4);

			//lvl6 = new Level6 (this);
			//AddScene (lvl6, 5);

			//lvl7 = new Level7 (this);
			//AddScene (lvl7, 6);

			//lvl8 = new Level8 (this);
			//AddScene (lvl8, 7);

			//mMenu = new MainMenu (this);

			//InGame Interface
			igInterface = new InGameInterface(this);
			AddScene (igInterface, 8);

			//Button;
			//AddScene(new ChangeLevel (this), 1);
		}

		public void Update(GameTime gameTime)
		{
			foreach (KeyValuePair<int, AScene> pairScene in _DScenes)
			{
				if (pairScene.Value.sceneState == SceneState.UPDATE || pairScene.Value.sceneState == SceneState.UPDATEDRAW) {
					pairScene.Value.Update (gameTime);
				}
			}
			UpdateScenes ();
		}

		public void Draw(GameTime gameTime)
		{
			foreach (KeyValuePair<int, AScene> pairScene in _DScenes)
				if (pairScene.Value.sceneState == SceneState.DRAW || pairScene.Value.sceneState == SceneState.UPDATEDRAW)
					pairScene.Value.Draw (gameTime);
		}


		public bool AddScene(AScene scene, int scenePos)
		{
			if (_DScenes.ContainsValue(scene))
					return false;
			scene.Initialize ();
			scene.LoadContent ();
			_DScenesToAdd [scenePos] = scene;
			return true;
		}

		public void RemoveScene(int scenePos)
		{
			if (!_DScenes.ContainsKey (scenePos))
				return ;
			_LScenesToRemove.Add (scenePos);
		}

		public AScene GetScene(int scenePos)
		{
			if (!_DScenes.ContainsKey(scenePos))
				return null;
			return _DScenes [scenePos];
		}

		public void UpdateScenes()
		{
			foreach (KeyValuePair<int, AScene> pairScene in _DScenesToAdd)
				_DScenes [pairScene.Key] = pairScene.Value;
			foreach (int sc in _LScenesToRemove)
				_DScenes.Remove (sc);
			_DScenesToAdd.Clear ();
			_LScenesToRemove.Clear ();
		}
	}
}

