using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace AppC_
{
    [Activity(Label = "�������", Theme = "@style/AppTheme")]
    public class ProfileActivity : AppCompatActivity
    {
        private EditText nameEditText;
        private EditText ageEditText;
        private EditText emailEditText;
        private Button saveButton;

        // ����� ��� SharedPreferences
        private const string PREFS_NAME = "UserData";
        private const string KEY_NAME = "name";
        private const string KEY_AGE = "age";
        private const string KEY_EMAIL = "email";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.layout1);
          
            nameEditText = FindViewById<EditText>(Resource.Id.nameEditText);
            ageEditText = FindViewById<EditText>(Resource.Id.ageEditText);
            emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            saveButton = FindViewById<Button>(Resource.Id.saveButton);
            saveButton.Click += SaveButton_Click;

            // ��������� ������ ������������
            LoadUserData();
        }

        // ����� ��� �������� ������ ������������
        private void LoadUserData()
        {
            // �������� SharedPreferences
            ISharedPreferences prefs = GetSharedPreferences(PREFS_NAME, FileCreationMode.Private);

            // ��������� ������ �� SharedPreferences
            string name = prefs.GetString(KEY_NAME, string.Empty);
            string age = prefs.GetString(KEY_AGE, string.Empty);
            string email = prefs.GetString(KEY_EMAIL, string.Empty);

            // ������������� ������ � ��������������� ����
            nameEditText.Text = name;
            ageEditText.Text = age;
            emailEditText.Text = email;
        }

        // ����� ��� ���������� ������ ������������
        private void SaveUserData(string name, string age, string email)
        {
            // �������� SharedPreferences
            ISharedPreferences prefs = GetSharedPreferences(PREFS_NAME, FileCreationMode.Private);

            // �������� �������� SharedPreferences
            ISharedPreferencesEditor editor = prefs.Edit();

            // ��������� ������ ������������
            editor.PutString(KEY_NAME, name);
            editor.PutString(KEY_AGE, age);
            editor.PutString(KEY_EMAIL, email);

            // ��������� ���������
            editor.Apply();
        }

        // �����, ���������� ��� ����� �� ������ ���������� ���������
        private void SaveButton_Click(object sender, System.EventArgs e)
        {
            // �������� ���������� ������ ������������
            string newName = nameEditText.Text;
            string newAge = ageEditText.Text;
            string newEmail = emailEditText.Text;

            // ��������� ������ ������������
            SaveUserData(newName, newAge, newEmail);

            // ������� ����������� �� �������� ����������
            Toast.MakeText(this, "������ ���������", ToastLength.Short).Show();
        }
    }
}
