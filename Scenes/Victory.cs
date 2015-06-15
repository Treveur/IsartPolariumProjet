using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace IsartPolarium
{
	public class Victory: AScene
	{
		//Button
		Button nextBtn;
		Button menuBtn;
		Button redoBtn;




		//GraphicsDeviceManager graphics;

		//Game1
		Game1 game;

		public Victory (SceneManager _SM) : base(_SM)
		{
		}

		public override void Initialize()
		{
			redoBtn = new Button (this, "resetBtn");
			redoBtn.Position = new Vector2 ((sceneManager.graphics.PreferredBackBufferWidth / 2) - 175, (sceneManager.graphics.PreferredBackBufferHeight / 2) + 200);
			menuBtn = new Button (this, "menuBtn");
			menuBtn.Position = new Vector2 (sceneManager.graphics.PreferredBackBufferWidth/2, (sceneManager.graphics.PreferredBackBufferHeight/2) + 200);
			nextBtn = new Button (this, "nextBtn");
			nextBtn.Position = new Vector2 ((sceneManager.graphics.PreferredBackBufferWidth/2) + 175, (sceneManager.graphics.PreferredBackBufferHeight/2) + 200);


			//Console.WriteLine ("Width : " + screenSize.Width + "Height :"+screenSize.Height);
			//Console.WriteLine ("Width : "+ sceneManager.graphics.PreferredBackBufferWidth +" Height : " + sceneManager.graphics.PreferredBackBufferHeight);

			base.Initialize ();
		}

		/// <summary>
		/// We load the content of our scene
		/// </summary>
		public override void LoadContent()
		{


			//Chargement du niveau 1
			sceneManager.lvl1 = new Level1 (sceneManager);
			sceneManager.AddScene (sceneManager.lvl1, 4);
			sceneManager.lvl1.sceneState = SceneState.SLEEP;

			AddEntity (nextBtn);
			AddEntity (menuBtn);
			AddEntity (redoBtn);


			base.LoadContent ();
		}

		/// <summary>
		/// We Update our scene.
		/// If it's the first time we enter in this function, we add our player and a grid.
		/// </summary>
		/// <param name="gameTime">Game time.</param>
		public override void Update (GameTime gameTime)
		{
			AddEntity (new VictorySprite (this));

			if (GetEntitiesNbr () == 0) {	
				//Ajout de l'entité player sur la scene
				//AddEntity (new Player (this));
				Player pl = new Player (this);
				AddEntity (pl);
			}

			if (nextBtn.changed && AdvancedMouse.OnRelease ()) {
				Console.WriteLine ("Youpi");

				sceneManager.mMenu.sceneState = SceneState.SLEEP;
				sceneManager.lvl1.sceneState = SceneState.UPDATEDRAW;
				sceneManager.igInterface.sceneState = SceneState.UPDATEDRAW;

			} else if (menuBtn.changed && AdvancedMouse.OnRelease ()) {
				game.Quit ();
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