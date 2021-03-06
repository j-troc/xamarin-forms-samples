﻿using Xamarin.Forms;

#if __IOS__
using CoreGraphics;
using UIKit;
using Xamarin.Forms.Platform.iOS;
#endif

#if __ANDROID__
using Android.Widget;
using Android.Views;
using Xamarin.Forms.Platform.Android;
#endif

#if WINDOWS_PHONE_APP
using System;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.WinRT;
#endif

#if WINDOWS_UWP
using System;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.UWP;
#endif

#if __TIZEN__
using System;
using Xamarin.Forms.Platform.Tizen;
#endif

namespace NestPlatformControl
{
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();

#if __IOS__
			const string originalText = "Native UILabel.";
			const string longerText = "Native UILabel. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut vel elit orci. Nam sollicitudin consectetur congue.";

			var uiLabel = new UILabel {
				MinimumFontSize = 14f,
				Lines = 0,
				LineBreakMode = UILineBreakMode.WordWrap,
				Text = originalText,
			};
			stackLayout.Children.Add (uiLabel);

			var uiButton = new UIButton (UIButtonType.RoundedRect);
			uiButton.SetTitle ("Change Text", UIControlState.Normal);
			uiButton.Font = UIFont.FromName ("Helvetica", 14f);
			uiButton.TouchUpInside += (sender, args) => {
				uiLabel.Text = uiLabel.Text == originalText ? longerText : originalText;
				uiLabel.SizeToFit ();
			};
			stackLayout.Children.Add (uiButton);

			var explanation1 = new UILabel {
				MinimumFontSize = 14f,
				Lines = 0,
				LineBreakMode = UILineBreakMode.WordWrap,
				Text = "The next control is a CustomControl (a customized UILabel with a bad SizeThatFits implementation).",
			};
			stackLayout.Children.Add (explanation1);

			var brokenControl = new CustomControl {
				MinimumFontSize = 14,
				Lines = 0,
				LineBreakMode = UILineBreakMode.WordWrap,
				Text = "This control has incorrect sizing - there's empty space above and below it."
			};
			stackLayout.Children.Add (brokenControl);

			var explanation2 = new UILabel {
				MinimumFontSize = 14f,
				Lines = 0,
				LineBreakMode = UILineBreakMode.WordWrap,
				Text = "The next control is a CustomControl, but an override to the GetDesiredSize method is passed in when adding the control to the layout.",
			};
			stackLayout.Children.Add (explanation2);

			var fixedControl = new CustomControl {
				MinimumFontSize = 14,
				Lines = 0,
				LineBreakMode = UILineBreakMode.WordWrap,
				Text = "This control has correct sizing - there's no empty space above and below it."
			};
			stackLayout.Children.Add (fixedControl, FixSize);
#endif

#if __ANDROID__
			const string originalText = "Native TextView.";
			const string longerText = "Native TextView. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut vel elit orci. Nam sollicitudin consectetur congue.";

			var textView = new TextView (Forms.Context) { Text = originalText, TextSize = 14 };
			textView.SetSingleLine (false);
			textView.SetLines (3);
			stackLayout.Children.Add (textView);

			var button = new Android.Widget.Button (Forms.Context) { Text = "Change Text" };
			button.Click += (sender, args) => {
				textView.Text = textView.Text == originalText ? longerText : originalText;
			};
			stackLayout.Children.Add (button);

			var explanation1 = new TextView (Forms.Context) {
				Text = "The next control is a CustomControl (a customized TextView with a bad OnMeasure implementation).",
				TextSize = 14
			};
			stackLayout.Children.Add (explanation1);

			var brokenControl = new CustomControl (Forms.Context) {
				Text = "This control has incorrect sizing - it doesn't occupy the available width of the device.",
				TextSize = 14
			};
			stackLayout.Children.Add (brokenControl);

			var explanation2 = new TextView (Forms.Context) {
				Text = "The next control is a CustomControl, but with a custom GetDesiredSize delegate to accomodate it's sizing problem.",
				TextSize = 14
			};
			stackLayout.Children.Add (explanation2);

			var goodControl = new CustomControl (Forms.Context) {
				Text = "This control has correct sizing - it occupies the available width of the device.",
				TextSize = 14
			};
			stackLayout.Children.Add (goodControl, FixSize);
#endif

#if WINDOWS_PHONE_APP
            const string originalText = "Native TextBlock.";
            const string longerText = "Native TextBlock. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut vel elit orci. Nam sollicitudin consectetur congue.";

            var textBlock = new TextBlock
            {
                Text = originalText,
                FontSize = 14,
                FontFamily = new FontFamily("HelveticaNeue"),
                TextWrapping = TextWrapping.Wrap
            };
            stackLayout.Children.Add(textBlock);

            var button = new Windows.UI.Xaml.Controls.Button { Content = "Change Text" };
            button.Click += (sender, args) => { textBlock.Text = textBlock.Text == originalText ? longerText : originalText; };
            stackLayout.Children.Add(button);

            var explanation1 = new TextBlock
            {
                Text = "The next control is a CustomControl (a customized TextBlock with a bad ArrangeOverride implementation).",
                FontSize = 14,
                FontFamily = new FontFamily("HelveticaNeue"),
                TextWrapping = TextWrapping.Wrap
            };
            stackLayout.Children.Add(explanation1);

            var brokenControl = new CustomControl { Text = "This control has incorrect sizing - it doesn't occupy the available width of the device." };
            stackLayout.Children.Add(brokenControl);

            var explanation2 = new TextBlock
            {
                Text = "The next control is a CustomControl, but an ArrangeOverride delegate is passed in when adding the control to the layout.",
                FontSize = 14,
                FontFamily = new FontFamily("HelveticaNeue"),
                TextWrapping = TextWrapping.Wrap
            };
            stackLayout.Children.Add(explanation2);

            var fixedControl = new CustomControl { Text = "This control has correct sizing - it occupies the available width of the device." };
            stackLayout.Children.Add(fixedControl, arrangeOverrideDelegate: (renderer, finalSize) =>
            {
                if (finalSize.Width <= 0 || double.IsInfinity(finalSize.Width))
                {
                    return null;
                }
                var frameworkElement = renderer.Control;
                frameworkElement.Arrange(new Rect(0, 0, finalSize.Width * 2, finalSize.Height));
                return finalSize;
            }); 
#endif

#if WINDOWS_UWP
            const string originalText = "Native TextBlock.";
            const string longerText = "Native TextBlock. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut vel elit orci. Nam sollicitudin consectetur congue.";

            var textBlock = new TextBlock
            {
                Text = originalText,
                FontSize = 14,
                FontFamily = new FontFamily("HelveticaNeue"),
                TextWrapping = TextWrapping.Wrap
            };
            stackLayout.Children.Add(textBlock);

            var button = new Windows.UI.Xaml.Controls.Button { Content = "Change Text" };
            button.Click += (sender, args) => { textBlock.Text = textBlock.Text == originalText ? longerText : originalText; };
            stackLayout.Children.Add(button);

            var explanation1 = new TextBlock
            {
                Text = "The next control is a CustomControl (a customized TextBlock with a bad ArrangeOverride implementation).",
                FontSize = 14,
                FontFamily = new FontFamily("HelveticaNeue"),
                TextWrapping = TextWrapping.Wrap
            };
            stackLayout.Children.Add(explanation1);

            var brokenControl = new CustomControl { Text = "This control has incorrect sizing - it doesn't occupy the available width of the device." };
            stackLayout.Children.Add(brokenControl);

            var explanation2 = new TextBlock
            {
                Text = "The next control is a CustomControl, but an ArrangeOverride delegate is passed in when adding the control to the layout.",
                FontSize = 14,
                FontFamily = new FontFamily("HelveticaNeue"),
                TextWrapping = TextWrapping.Wrap
            };
            stackLayout.Children.Add(explanation2);

            var fixedControl = new CustomControl { Text = "This control has correct sizing - it occupies the available width of the device." };
            stackLayout.Children.Add(fixedControl, arrangeOverrideDelegate: (renderer, finalSize) =>
            {
                if (finalSize.Width <= 0 || double.IsInfinity(finalSize.Width))
                {
                    return null;
                }
                var frameworkElement = renderer.Control;
                frameworkElement.Arrange(new Rect(0, 0, finalSize.Width * 2, finalSize.Height));
                return finalSize;
            });
#endif

#if __TIZEN__
			const string originalText = "Native ElmSharp.Label.";
			const string longerText = "Native ElmSharp.Label. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut vel elit orci. Nam sollicitudin consectetur congue.";

			var label = new ElmSharp.Label(Tizen.Program.ElmWindow)
			{
				Text = originalText,
				// Line Wrap does not applied to longerText as expected because ElmSharp.Label does not measure itself.
				LineWrapType = ElmSharp.WrapType.Char
			};
			stackLayout.Children.Add(label);

			var button = new ElmSharp.Button(Tizen.Program.ElmWindow)
			{
				Text = "Change Text"
			};
			button.Clicked += (sender, args) =>
			{
				label.Text = label.Text == originalText ? longerText : originalText;
			};
			stackLayout.Children.Add(button);

			var explanation1 = new ElmSharp.Label(Tizen.Program.ElmWindow)
			{
				Text = "The next control is a CustomControl (a customized ElmSharp.Label without any measurement method).",
				LineWrapType = ElmSharp.WrapType.Char,
			};
			// measureDelegate is required to show the line wrap option properly.
			stackLayout.Children.Add(explanation1, FixSize);

			var brokenControl = new CustomControl(Tizen.Program.ElmWindow)
			{
				Text = "This control has incorrect sizing - there's empty space above and below it.",
				FontSize = 28
			};
			stackLayout.Children.Add(brokenControl);

			var explanation2 = new ElmSharp.Label(Tizen.Program.ElmWindow)
			{
				Text = "The next control is a CustomControl, but with a custom GetDesiredSize delegate to accomodate it's sizing problem.",
				LineWrapType = ElmSharp.WrapType.Word,
			};
			stackLayout.Children.Add(explanation2, FixSize);

			var goodControl = new CustomControl(Tizen.Program.ElmWindow)
			{
				Text = "This control has correct sizing - it occupies the available size of the device - (one two three four five six).",
				FontSize = 28
			};
			stackLayout.Children.Add(goodControl, FixSize);
#endif
        }

        #if __IOS__
		SizeRequest? FixSize (NativeViewWrapperRenderer renderer, double width, double height)
		{
			var uiView = renderer.Control;

			if (uiView == null) {
				return null;
			}

			var constraint = new CGSize (width, height);

			// Let the CustomControl determine its size (which will be wrong)
			var badRect = uiView.SizeThatFits (constraint);

			// Use the width and substitute the height
			return new SizeRequest (new Size (badRect.Width, 70));
		}
		#endif

		#if __ANDROID__
		SizeRequest? FixSize (NativeViewWrapperRenderer renderer, int widthConstraint, int heightConstraint)
		{
			var nativeView = renderer.Control;

			if ((widthConstraint == 0 && heightConstraint == 0) || nativeView == null) {
				return null;
			}

			int width = Android.Views.View.MeasureSpec.GetSize (widthConstraint);
			int widthSpec = Android.Views.View.MeasureSpec.MakeMeasureSpec (width * 2, Android.Views.View.MeasureSpec.GetMode (widthConstraint));
			nativeView.Measure (widthSpec, heightConstraint);
			return new SizeRequest (new Size (nativeView.MeasuredWidth, nativeView.MeasuredHeight));
		}
#endif

		#if __TIZEN__
		ElmSharp.Size? FixSize (EvasObjectWrapperRenderer renderer, int availableWidth, int availableHeight)
		{
			var nativeView = renderer.NativeView as ElmSharp.Label;

			if ((availableWidth == 0 && availableHeight == 0) || nativeView == null)
			{
				return null;
			}

			var size = nativeView.Geometry;

			nativeView.Resize(availableWidth, size.Height);

			var rawSize = nativeView.EdjeObject["elm.text"].TextBlockNativeSize;
			var formattedSize = nativeView.EdjeObject["elm.text"].TextBlockFormattedSize;

			nativeView.Resize(size.Width, size.Height);

			// Set bottom padding for lower case letters that have segments below the bottom line of text (g, j, p, q, y).
			if (nativeView is CustomControl customView)
			{
				var verticalPadding = (int)Math.Ceiling(0.05 * customView.FontSize);
				rawSize.Height += verticalPadding;
				formattedSize.Height += verticalPadding;
			}

			if (rawSize.Width > availableWidth)
			{
				return new ElmSharp.Size()
				{
					Width = formattedSize.Width,
					Height = Math.Min(formattedSize.Height, Math.Max(rawSize.Height, availableHeight)),
				};
			}
			else
			{
				return formattedSize;
			}
		}
#endif
	}
}
