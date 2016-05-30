using UnityEngine;
using UnityEditor;
using System.Collections;
using BaseFrame.QUI;
using BaseFrame.QUI.Data;
using BaseFrame.CustomEditor;

namespace BaseFrame.QUI.Editors {

	/// <summary>
	/// Draws QUI related editor windows or panels.
	/// </summary>
    public class QUIDraw {

		/// <summary>
		/// Draws the QUIAnimationData panel.
		/// </summary>
		/// <returns>The animation data.</returns>
		/// <param name="_data">The animation data.</param>
		/// <param name="_titleName">The name of the animation data.</param>
        public static QUIAnimationData DrawAnimationDataPanel (QUIAnimationData _data, string _titleName) {

            QUIAnimationData data = _data;

            EditorGUILayout.BeginVertical("Box");
            data.isShownInEditor = Draw.TitleWithToggle(data.isShownInEditor, _titleName);

            if (data.isShownInEditor) {

                Draw.TitleField("Overall");
                EditorGUILayout.BeginVertical("Box");

                data.delay = Draw.FloatField(data.delay, "Start Delay");
                data.defaultGraphic = Draw.DrawSpriteField(data.defaultGraphic, "Graphic", false);

                EditorGUILayout.EndVertical();



                EditorGUILayout.BeginVertical(EditorStyles.objectFieldThumb);
                EditorGUILayout.LabelField("Transform");
                data.movementData = QUIDraw.DrawMovementDataPanel(data.movementData);
                data.rotationData = QUIDraw.DrawRotationDataPanel(data.rotationData);
                data.scaleData = QUIDraw.DrawScaleDataPanel(data.scaleData);
                EditorGUILayout.EndVertical();

                EditorGUILayout.Space();

                EditorGUILayout.BeginVertical(EditorStyles.objectFieldThumb);
                EditorGUILayout.LabelField("Graphic");
                data.fadeData = QUIDraw.DrawFadeDataPanel(data.fadeData);
                data.colorData = QUIDraw.DrawColorDataPanel(data.colorData);
                EditorGUILayout.EndVertical();

                EditorGUILayout.BeginVertical(EditorStyles.objectFieldThumb);
                EditorGUILayout.LabelField("Others");


                data.isAudioVisibleInEditor = Draw.TitleWithToggle(data.isAudioVisibleInEditor, "Sound Effect");
                if (data.isAudioVisibleInEditor) {

                    data.startAudioEffect = DrawAudioAnimationDataPanel(data.startAudioEffect, "Start Sound");
                    data.completeAudioEffect = DrawAudioAnimationDataPanel(data.completeAudioEffect, "Complete Sound");

                }

                EditorGUILayout.EndVertical();

            }

            EditorGUILayout.EndHorizontal();

            return data;

        }

		/// <summary>
		/// Draws the movement data panel.
		/// </summary>
		/// <returns>The movement data.</returns>
		/// <param name="_data">The movement data.</param>
        public static QUIMovementAnimationData DrawMovementDataPanel (QUIMovementAnimationData _data) {

            QUIMovementAnimationData data = _data;

            data.isVisibleInEditor = Draw.TitleWithToggle(data.isVisibleInEditor, "Movement");
            if (data.isVisibleInEditor) {

                data.usesAnimation = Draw.ToggleField(data.usesAnimation, "Uses Move Animation");

                if (data.usesAnimation) {

                    EditorGUILayout.BeginVertical("Box");
                    data.useStartValue = Draw.ToggleField(data.useStartValue, "Use Start Position");
                    if (data.useStartValue)
                        data.startPosition = Draw.DrawVector2Field(data.startPosition, "Start Position");
                    data.endPosition = Draw.DrawVector2Field(data.endPosition, "End Position");
                    data.animationTime = Draw.FloatField(data.animationTime, "Time");
                    data.delay = Draw.FloatField(data.delay, "Start Delay");
                    data.easeType = Draw.DrawEaseField(data.easeType, "Easing Type");
                    EditorGUILayout.EndVertical();

                }

            }

            return data;

        }

		/// <summary>
		/// Draws the rotation data panel.
		/// </summary>
		/// <returns>The rotation data.</returns>
		/// <param name="_data">The rotation data.</param>
        public static QUIRotationAnimationData DrawRotationDataPanel (QUIRotationAnimationData _data) {

            QUIRotationAnimationData data = _data;

            data.isVisibleInEditor = Draw.TitleWithToggle(data.isVisibleInEditor, "Rotation");
            if (data.isVisibleInEditor) {

                data.usesAnimation = Draw.ToggleField(data.usesAnimation, "Uses Rotation Animation");

                if (data.usesAnimation) {

                    EditorGUILayout.BeginVertical("Box");
                    data.useStartValue = Draw.ToggleField(data.useStartValue, "Use Start Rotation");
                    if (data.useStartValue)
                        data.startRotation = Draw.DrawVector3Field(data.startRotation, "Start Rotation Value");
                    data.endRotation = Draw.DrawVector3Field(data.endRotation, "End Rotation Value");
                    data.animationTime = Draw.FloatField(data.animationTime, "Time");
                    data.delay = Draw.FloatField(data.delay, "Start Delay");
                    data.easeType = Draw.DrawEaseField(data.easeType, "Easing Type");
                    EditorGUILayout.EndVertical();

                }

            }

            return data;

        }

		/// <summary>
		/// Draws the scale data panel.
		/// </summary>
		/// <returns>The scale data.</returns>
		/// <param name="_data">The scale data.</param>
        public static QUIScaleAnimationData DrawScaleDataPanel (QUIScaleAnimationData _data) {

            QUIScaleAnimationData data = _data;

            data.isVisibleInEditor = Draw.TitleWithToggle(data.isVisibleInEditor, "Scale");
            if (data.isVisibleInEditor) {

                data.usesAnimation = Draw.ToggleField(data.usesAnimation, "Uses Scale Animation");

                if (data.usesAnimation) {

                    EditorGUILayout.BeginVertical("Box");
                    data.useStartValue = Draw.ToggleField(data.useStartValue, "Use Start Scale");
                    if (data.useStartValue)
                        data.startScale = Draw.FloatField(data.startScale, "Start Scale Value");
                    data.endScale = Draw.FloatField(data.endScale, "End Scale Value");
                    data.animationTime = Draw.FloatField(data.animationTime, "Time");
                    data.delay = Draw.FloatField(data.delay, "Start Delay");
                    data.easeType = Draw.DrawEaseField(data.easeType, "Easing Type");
                    EditorGUILayout.EndVertical();

                }

            }

            return data;

        }

		/// <summary>
		/// Draws the fade data panel.
		/// </summary>
		/// <returns>The fade data.</returns>
		/// <param name="_data">The fade data.</param>
        public static QUIFadeAnimationData DrawFadeDataPanel (QUIFadeAnimationData _data) {

            QUIFadeAnimationData data = _data;

            data.isVisibleInEditor = Draw.TitleWithToggle(data.isVisibleInEditor, "Fade");
            if (data.isVisibleInEditor) {

                data.usesAnimation = Draw.ToggleField(data.usesAnimation, "Uses Fade Animation");

                if (data.usesAnimation) {

                    EditorGUILayout.BeginVertical("Box");
                    data.useStartValue = Draw.ToggleField(data.useStartValue, "Use Start Fade Value");
                    if (data.useStartValue)
                        data.startFadeValue = Draw.FloatField(data.startFadeValue, "Start Fade Value");
                    data.endFadeValue = Draw.FloatField(data.endFadeValue, "End Fade Value");
                    data.animationTime = Draw.FloatField(data.animationTime, "Time");
                    data.delay = Draw.FloatField(data.delay, "Start Delay");
                    data.easeType = Draw.DrawEaseField(data.easeType, "Easing Type");
                    EditorGUILayout.EndVertical();

                }

            }

            return data;

        }

		/// <summary>
		/// Draws the color data panel.
		/// </summary>
		/// <returns>The color data.</returns>
		/// <param name="_data">The color data.</param>
        public static QUIColorAnimationData DrawColorDataPanel (QUIColorAnimationData _data) {

            QUIColorAnimationData data = _data;

            data.isVisibleInEditor = Draw.TitleWithToggle(data.isVisibleInEditor, "Color");
            if (data.isVisibleInEditor) {

                data.usesAnimation = Draw.ToggleField(data.usesAnimation, "Uses Color Animation");

                if (data.usesAnimation) {

                    EditorGUILayout.BeginVertical("Box");
                    data.useStartValue = Draw.ToggleField(data.useStartValue, "Use Start Color Value");
                    if (data.useStartValue)
                        data.startColorValue = Draw.ColorField(data.startColorValue, "Start Color Value");
                    data.endColorValue = Draw.ColorField(data.endColorValue, "End Color Value");
                    data.animationTime = Draw.FloatField(data.animationTime, "Time");
                    data.delay = Draw.FloatField(data.delay, "Start Delay");
                    data.easeType = Draw.DrawEaseField(data.easeType, "Easing Type");
                    EditorGUILayout.EndVertical();

                }

            }

            return data;

        }

		/// <summary>
		/// Draws the audio animation data panel.
		/// </summary>
		/// <returns>The audio animation data.</returns>
		/// <param name="_data">The audio animation data.</param>
		/// <param name="_title">Title of the audio Animation.</param>
        public static QUIAudioAnimationData DrawAudioAnimationDataPanel (QUIAudioAnimationData _data, string _title) {

            QUIAudioAnimationData data = _data;

            EditorGUILayout.BeginVertical("Box");
            Draw.TitleField(_title);
            data.usesSoundEffect = Draw.ToggleField(data.usesSoundEffect, "Uses Sound Effect");

            if (data.usesSoundEffect) {

                EditorGUILayout.BeginVertical("Box");
                data.soundEffect.objectPrefab = Draw.DrawGameObjectField(data.soundEffect.objectPrefab, "Sound Effect Prefab", false);
                data.soundEffectDelay = Draw.FloatField(data.soundEffectDelay, "Start Delay");
                EditorGUILayout.EndVertical();

            }

            EditorGUILayout.EndVertical();

            return data;

        }

    }

}