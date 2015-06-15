using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
namespace IsartPolarium
{
	public class PauseMenu: AScene
	{
		//Buttons
		Button returnBtn;
		Button principalMenuBtn;

		Sprite blackBkg;
		
		//GraphicsDeviceManager graphics;

		public PauseMenu (SceneManager _SM) : base(_SM)
		{
		}

		public override void Initialize()
		{
			returnBtn = new Button (this, "returnBtn");
			returnBtn.Position = new Vector2 ((sceneManager.graphics.PreferredBackBufferWidth / 2), (sceneManager.graphics.PreferredBackBufferHeight / 2) - 75);

			principalMenuBtn = new Button (this, "menuPrincipalBtn");
			principalMenuBtn.Position = new Vector2 ((sceneManager.graphics.PreferredBackBufferWidth / 2), (sceneManager.graphics.PreferredBackBufferHeight / 2)+75);


			base.Initialize ();
		}

		/// <summary>
		/// We load the content of our scene
		/// </summary>
		public override void LoadContent()
		{
			//Chargement et affichage bkg
			blackBkg = new Sprite ("blackPauseMenu");

			blackBkg.depth = 0.6f;
			blackBkg.scale = 0.5f;
			//AEntity.LinkSprite (blackBkg);

			AddEntity (returnBtn);
			AddEntity (principalMenuBtn);

			base.LoadContent ();
		}

		/// <summary>
		/// We Update our scene.
		/// If it's the first time we enter in this function, we add our player and a grid.
		/// </summary>
		/// <param name="gameTime">Game time.</param>
		public override void Update (GameTime gameTime)
		{

			if (returnBtn.changed && AdvancedMouse.OnReleaseState) {
				
				if (sceneManager.lvl1.sceneState == SceneState.DRAW) {
					sceneManager.lvl1.sceneState = SceneState.UPDATEDRAW;
				} else if (sceneManager.lvl2.sceneState == SceneState.DRAW) {
					sceneManager.lvl2.sceneState = SceneState.UPDATEDRAW;
				} else if (sceneManager.lvl3.sceneState == SceneState.DRAW) {
					sceneManager.lvl3.sceneState = SceneState.UPDATEDRAW;
				} else if (sceneManager.lvl4.sceneState == SceneState.DRAW) {
					sceneManager.lvl4.sceneState = SceneState.UPDATEDRAW;
				} else if (sceneManager.lvl5.sceneState == SceneState.DRAW) {
					sceneManager.lvl5.sceneState = SceneState.UPDATEDRAW;
				} else if (sceneManager.lvl6.sceneState == SceneState.DRAW) {
					sceneManager.lvl6.sceneState = SceneState.UPDATEDRAW;
				} else if (sceneManager.lvl7.sceneState == SceneState.DRAW) {
					sceneManager.lvl7.sceneState = SceneState.UPDATEDRAW;
				} else if (sceneManager.lvl8.sceneState == SceneState.DRAW) {
					sceneManager.lvl8.sceneState = SceneState.UPDATEDRAW;
				}

				sceneManager.igInterface.sceneState = SceneState.UPDATEDRAW;
				sceneState = SceneState.SLEEP;
				sceneManager.bPause.sceneState = SceneState.SLEEP;

				returnBtn.changed = false;


			} else if(principalMenuBtn.changed && AdvancedMouse.OnReleaseState){
				if (sceneManager.lvl1.sceneState == SceneState.DRAW) {
					sceneManager.lvl1.sceneState = SceneState.SLEEP;
				} else if (sceneManager.lvl2.sceneState == SceneState.DRAW) {
					sceneManager.RemoveScene (5);
				} else if (sceneManager.lvl3.sceneState == SceneState.DRAW) {
					sceneManager.RemoveScene (6);
				} else if (sceneManager.lvl4.sceneState == SceneState.DRAW) {
					sceneManager.RemoveScene (7);
				} else if (sceneManager.lvl5.sceneState == SceneState.DRAW) {
					sceneManager.RemoveScene (8);
				} else if (sceneManager.lvl6.sceneState == SceneState.DRAW) {
					sceneManager.RemoveScene (9);
				} else if (sceneManager.lvl7.sceneState == SceneState.DRAW) {
					sceneManager.RemoveScene (10);
				} else if (sceneManager.lvl8.sceneState == SceneState.DRAW) {
					sceneManager.RemoveScene (11);
				}

				sceneManager.pMenu.sceneState = SceneState.SLEEP;
				sceneManager.bPause.sceneState = SceneState.SLEEP;
				sceneManager.mMenu.sceneState = SceneState.UPDATEDRAW;

				principalMenuBtn.changed = false;
			}



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