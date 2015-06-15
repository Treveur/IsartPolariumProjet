using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
namespace IsartPolarium
{
	public class InGameInterface: AScene
	{

		public Button validateBtn;
		Button resetGameBtn;
		Button menuBtn;
		//GraphicsDeviceManager graphics;

		public InGameInterface (SceneManager _SM) : base(_SM)
		{
		}

		public override void Initialize()
		{
			menuBtn = new Button (this, "menuBtn");
			menuBtn.Position = new Vector2 ((50 + 40),  (50 + 40));

			resetGameBtn = new Button (this, "resetBtn");
			resetGameBtn.Position = new Vector2 ((sceneManager.graphics.PreferredBackBufferWidth - 50) - 40, (50 + 40));

			validateBtn = new Button (this, "valider");
			validateBtn.Position = new Vector2 (sceneManager.graphics.PreferredBackBufferWidth/2, (sceneManager.graphics.PreferredBackBufferHeight) - 75 - 40);

			base.Initialize ();
		}

		/// <summary>
		/// We load the content of our scene
		/// </summary>
		public override void LoadContent()
		{
			AddEntity (validateBtn);
			AddEntity (resetGameBtn);
			AddEntity (menuBtn);


			base.LoadContent ();
		}

		/// <summary>
		/// We Update our scene.
		/// If it's the first time we enter in this function, we add our player and a grid.
		/// </summary>
		/// <param name="gameTime">Game time.</param>
		public override void Update (GameTime gameTime)
		{

			if (GetEntitiesNbr () == 0) {	
				//Ajout de l'entité player sur la scene
				//AddEntity (new Player (this));
				Player pl = new Player (this);
				AddEntity (pl);
			}


			if (menuBtn.changed && AdvancedMouse.OnRelease ()) {
				//Menu principale : 0
				//ingame interface : 3
				//Pause Menu :2

				//Console.WriteLine (sceneManager.);
			} else if(resetGameBtn.changed && AdvancedMouse.OnRelease ()){
				//Console.WriteLine ("Reset");

				//Reset du level
				if (sceneManager.lvl1.sceneState == SceneState.UPDATEDRAW) {
					sceneManager.RemoveScene (4);
					sceneManager.lvl1 = new Level1 (sceneManager);
					sceneManager.AddScene (sceneManager.lvl1, 4);
				} else if (sceneManager.lvl2.sceneState == SceneState.UPDATEDRAW) {
					sceneManager.RemoveScene (5);
					sceneManager.lvl2 = new Level2 (sceneManager);
					sceneManager.AddScene (sceneManager.lvl1, 5);
				} else if (sceneManager.lvl3.sceneState == SceneState.UPDATEDRAW) {
				} else if (sceneManager.lvl4.sceneState == SceneState.UPDATEDRAW) {
				} else if (sceneManager.lvl5.sceneState == SceneState.UPDATEDRAW) {
				} else if (sceneManager.lvl6.sceneState == SceneState.UPDATEDRAW) {
				} else if (sceneManager.lvl7.sceneState == SceneState.UPDATEDRAW) {
				} else if (sceneManager.lvl8.sceneState == SceneState.UPDATEDRAW) {
				}

				resetGameBtn.changed = false;
			}


			/*if (ULvl1.changed || DLvl1.changed) {
				ChangeSceneState (ULvl1._state, DLvl1._state, sceneManager.GetScene(1));
				ULvl1.changed = false;
				DLvl1.changed = false;
			}

			if (ULvl2.changed || DLvl2.changed) {
				sceneManager.GetScene(0).sceneState = ChangeSceneState (ULvl2._state, DLvl2._state);
				ULvl2.changed = false;
				DLvl2.changed = false;
			}*/

			base.Update (gameTime);
		}

		SceneState ChangeSceneState(bool upd, bool dra)
		{
			if (upd && dra)
				return SceneState.UPDATEDRAW;
			else if (upd == false && dra)
				return SceneState.DRAW;
			else if (upd && dra == false)
				return SceneState.UPDATE;
			else if (upd == false && dra == false)
				return SceneState.SLEEP;
			return SceneState.SLEEP;
		}

		void ChangeSceneState(bool upd, bool dra, AScene sceneToChange)
		{
			if (upd && dra)
				sceneToChange.sceneState = SceneState.UPDATEDRAW;
			else if (upd == false && dra)
				sceneToChange.sceneState = SceneState.DRAW;
			else if (upd && dra == false)
				sceneToChange.sceneState = SceneState.UPDATE;
			else if (upd == false && dra == false)
				sceneToChange.sceneState = SceneState.SLEEP;
		}

		public void  validateLevel(AScene scene){
			if (validateBtn.changed && AdvancedMouse.OnRelease()){
				Console.WriteLine ("Je valide");
				scene.
				sceneManager.lvl1.sceneState = SceneState.DRAW;
				//SwitchState (saveState);
			}
		}

		/// <summary>
		/// We draw all the entity of our scene
		/// </summary>
		/// <param name="gameTime">Game time.</param>
		public override void Draw(GameTime gameTime)
		{
			base.Draw (gameTime);
		}
	}
}