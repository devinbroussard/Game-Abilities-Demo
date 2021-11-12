using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGamesAssessment
{
    class HealthCounter : UIText
    {
        private Character _character;

        public HealthCounter(Color color, Character character)
            : base(character.WorldPosition.X, character.WorldPosition.Y + 1, character.WorldPosition.Z, Shape.NULL, "Health Counter", Color.WHITE)
        {
            _character = character;
            Text = _character.Health.ToString();
        }

    public override void Update(float deltaTime)
    {

        if (_character.Health > 0)
        {//
            base.SetTranslation(_character.WorldPosition.X, _character.WorldPosition.Y + 1, _character.WorldPosition.Z);
            Text = _character.Health.ToString();
        }

        else
            Engine.CurrentScene.RemoveUIElement(this);

        base.Update(deltaTime);
    }
}
}
