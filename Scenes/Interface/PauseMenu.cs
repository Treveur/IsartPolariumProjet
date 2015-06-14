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

			if (GetEntitiesNbr () == 0) {	
				//Ajout de l'entité player sur la scene
				//AddEntity (new Player (this));
				Player pl = new Player (this);
				AddEntity (pl);
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