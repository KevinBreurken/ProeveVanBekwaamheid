using UnityEngine;
using UnityEditor;
using System.Collections;
using QUI;
using QUI.Data;
using Base.CustomEditor;

namespace QUI.Editors {

    public class QUIDraw {

        public static QUIAnimationData DrawAnimationDataPanel (QUIAnimationData _data, string _titleName) {

            QUIAnimationData data = _data;

            EditorGUILayout.BeginVertical("Box");
            data.isShownInEditor = Draw.TitleWithToggle(data.isShownInEditor, _titleName);

            if (data.isShownInEditor) {

                Draw.TitleField("Overall");
                EditorGUILayout.BeginVertical("Box");

                data.delay = Draw.FloatField(data.delay, "Start Delay");
                data.graphic = Draw.DrawSpriteField(data.graphic, "Graphic", false);

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


                data.isAudioShownInEditor = Draw.TitleWithToggle(data.isAudioShownInEditor, "Sound Effect");
                if (data.isAudioShownInEditor) {

                    data.startAudioEffect = DrawAudioAnimationDataPanel(data.startAudioEffect, "Start Sound");
                    data.completeAudioEffect = DrawAudioAnimationDataPanel(data.completeAudioEffect, "Complete Sound");

                }

                EditorGUILayout.EndVertical();

            }

            EditorGUILayout.EndHorizontal();

            return data;

        }

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