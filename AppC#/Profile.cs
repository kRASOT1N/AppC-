using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace AppC_
{
    [Activity(Label = "Профиль", Theme = "@style/AppTheme")]
    public class ProfileActivity : AppCompatActivity
    {
        private EditText nameEditText;
        private EditText ageEditText;
        private EditText emailEditText;
        private Button saveButton;

        // Ключи для SharedPreferences
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

            // Загружаем данные пользователя
            LoadUserData();
        }

        // Метод для загрузки данных пользователя
        private void LoadUserData()
        {
            // Получаем SharedPreferences
            ISharedPreferences prefs = GetSharedPreferences(PREFS_NAME, FileCreationMode.Private);

            // Загружаем данные из SharedPreferences
            string name = prefs.GetString(KEY_NAME, string.Empty);
            string age = prefs.GetString(KEY_AGE, string.Empty);
            string email = prefs.GetString(KEY_EMAIL, string.Empty);

            // Устанавливаем данные в соответствующие поля
            nameEditText.Text = name;
            ageEditText.Text = age;
            emailEditText.Text = email;
        }

        // Метод для сохранения данных пользователя
        private void SaveUserData(string name, string age, string email)
        {
            // Получаем SharedPreferences
            ISharedPreferences prefs = GetSharedPreferences(PREFS_NAME, FileCreationMode.Private);

            // Получаем редактор SharedPreferences
            ISharedPreferencesEditor editor = prefs.Edit();

            // Сохраняем данные пользователя
            editor.PutString(KEY_NAME, name);
            editor.PutString(KEY_AGE, age);
            editor.PutString(KEY_EMAIL, email);

            // Применяем изменения
            editor.Apply();
        }

        // Метод, вызываемый при клике на кнопку сохранения изменений
        private void SaveButton_Click(object sender, System.EventArgs e)
        {
            // Получаем измененные данные пользователя
            string newName = nameEditText.Text;
            string newAge = ageEditText.Text;
            string newEmail = emailEditText.Text;

            // Сохраняем данные пользователя
            SaveUserData(newName, newAge, newEmail);

            // Выводим уведомление об успешном сохранении
            Toast.MakeText(this, "Данные сохранены", ToastLength.Short).Show();
        }
    }
}
