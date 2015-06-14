using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace IsartPolarium
{
	public class GameCase : AEntity
	{

		public enum e_state
		{
			NONE,
			ON_DRAG,
			PILE,
			FACE,
			SPECIAL_PILE,
			SPECIAL_FACE,
			GRAY
		}

		//Initisation variable qui sert a la vérification afin de savoir si on peut passer sur la case ou pas
		private static GameCase lastCase;
		public Vector2 coordonnee;

		//Compte le nombre de case qui sont en on_drag
		static int nbrOnDrag;

		//Sprite
		Sprite sg;
		Sprite bc;

		bool isAlreadyEven = false;

		Color dragColor = Color.Yellow;

		public e_state actualState = e_state.NONE;
		e_state saveState = e_state.NONE;
		e_state previousState = e_state.NONE;

		public GameCase (AScene scene) : base(scene)
		{

		}

		public override void Initialize()
		{
			base.Initialize ();
		}

		public override void LoadContent()
		{
			bc = new Sprite ("Case");
			sg = new Sprite ("Mouse");
			LinkSprite ("Test_Tile");
			sprite.position = new Vector2 (20f, 20f);

			sg.position = sprite.position;
			sprite.depth = 1f;
			sg.depth = 1f;

			base.LoadContent ();
		}

		public override void Update(GameTime gameTime)
		{
			
			Rectangle area = hitBox;

			if (area.Contains (AdvancedMouse.Position) && AdvancedMouse.OnDrag () && !(actualState == e_state.ON_DRAG))
			{	
				if (lastCase == null) {
					//On met les bon états
					saveState = actualState;
					actualState = e_state.ON_DRAG;
					LinkSprite (sg);
					sprite.depth = 0.9f;
					lastCase = this;


				} else {
					if (lastCaseAround()) {
						saveState = actualState;
						actualState = e_state.ON_DRAG;
						sprite.depth = 0.9f;
						LinkSprite (sg);
						lastCase = this;
					}
				}

				//increment nbrOnDrag
				nbrOnDrag++;


			}
			else if (actualState == e_state.ON_DRAG && AdvancedMouse.OnRelease ())
			{

				//Console.WriteLine (saveState.ToString());
				SwitchState (saveState);

				lastCase = null;
				LinkSprite (bc);

				//reset variable
				nbrOnDrag = 0;
			}


			changeSpecialCase (nbrOnDrag);




			//Console.WriteLine (nbrOnDrag);


			linkTile ();

			previousState = actualState;

			// Permet de récupérer la position de la case pour le placement du Character en Player
			if (AdvancedMouse.OnDrag() && area.Contains (AdvancedMouse.Position)) {
				//Console.WriteLine ("x" + sprite.position.X + "y" + sprite.position.Y);
				Player.MovePlayer (sprite.position);
			}

			base.Update (gameTime);
		}

		//Fonction qui permet de savoir si on peut repasser sur une ligne
		public  bool lastCaseAround() {
			return 	(lastCase.coordonnee.X == this.coordonnee.X - 1 && lastCase.coordonnee.Y == this.coordonnee.Y) ||
				(lastCase.coordonnee.X == this.coordonnee.X + 1 && lastCase.coordonnee.Y == this.coordonnee.Y) ||
				(lastCase.coordonnee.X == this.coordonnee.X && lastCase.coordonnee.Y == this.coordonnee.Y - 1 )||
				(lastCase.coordonnee.X == this.coordonnee.X && lastCase.coordonnee.Y == this.coordonnee.Y + 1);
		}

		public override void Draw(GameTime gameTime)
		{

			base.Draw (gameTime);
		}

		//Change state of tiles
		private void SwitchState(e_state lastState)
		{
			if (lastState == e_state.PILE) {
				actualState = e_state.FACE;
			} else if (lastState == e_state.GRAY) {
				actualState = e_state.GRAY;
			} else if (lastState == e_state.SPECIAL_FACE) {
				actualState = e_state.SPECIAL_PILE;
			} else if (lastState == e_state.SPECIAL_PILE) {
				actualState = e_state.SPECIAL_FACE;
			} else if (lastState == e_state.FACE) {
				actualState = e_state.PILE;
			}
		}

		//Link image to the tile
		private void linkTile(){

			if (actualState == previousState) {
				return;
			}

			switch (actualState) {
			case e_state.PILE:
				LinkSprite ("Orange_Tile");
				sprite.depth = 1f;
				sg.depth = 0.9f;
				break;

			case e_state.FACE:
				LinkSprite ("Beige_Tile");
				sprite.depth = 0.9f;
				sg.depth = 1f;
				break;

			case e_state.GRAY:
				LinkSprite ("Grey_Tile");
				sprite.depth = 0.9f;
				sg.depth = 1f;
				break;

			case e_state.ON_DRAG:
				LinkSprite ("Test_Tile");
				sprite.depth = 0.9f;
				sg.depth = 1f;
				break;

			case e_state.SPECIAL_FACE:
				LinkSprite ("Tile_SPE_FACE", 1, 4, 4, 50);
				sprite.depth = 0.9f;
				sg.depth = 1f;
				break;

			case e_state.SPECIAL_PILE:
				LinkSprite ("Tile_SPE_PILE", 1, 4, 4, 50);
				sprite.depth = 0.9f;
				sg.depth = 1f;
				break;
			}

			//Changement de l'echelle des sprites
			//sprite.scale = 1f;
		}

		/// <summary>
		/// Change the special Case
		/// </summary>
		/// <param name="caseOnDrag">Number of case is on_drag</param>
		private void changeSpecialCase(int caseOnDrag){

			if (caseOnDrag % 2 != 0) {
				isAlreadyEven = false;
			}

			if (!isAlreadyEven) {
				//Verification if caseOnDrag is even and different to 0 and if the actualState of the case is Special Pile or Special Face
				if ((caseOnDrag != 0 && caseOnDrag % 2 == 0) && (actualState == e_state.SPECIAL_PILE || actualState == e_state.SPECIAL_FACE)) {

					Console.WriteLine("Ca change");

					SwitchState (actualState);

					isAlreadyEven = true;
				}

			}



		}
	}
}
