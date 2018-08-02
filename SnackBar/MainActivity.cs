using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.Design.Widget;

namespace SnackBar
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        CoordinatorLayout rootView;
        static TextView actionText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            rootView = FindViewById<CoordinatorLayout>(Resource.Id.root_view);
            actionText = FindViewById<TextView>(Resource.Id.action_text);

            FindViewById<Button>(Resource.Id.btn_show_snackbar).Click += (sender, e) =>
            {
                var snackbar = Snackbar.Make(rootView, "I'm a snackbar!", Snackbar.LengthLong)
                .SetAction("Click Me", v => actionText.Text = "Snackbar was clicked!");
                snackbar.AddCallback(new MySnackbarCallback());
                snackbar.Show();
            };
        }

        class MySnackbarCallback : Snackbar.Callback
        {
            public override void OnDismissed(Snackbar transientBottomBar, int @event)
            {
                base.OnDismissed(transientBottomBar, @event);
                if (@event != DismissEventAction)
                    actionText.Text = "Placeholder text";
            }
        }
    }
}

