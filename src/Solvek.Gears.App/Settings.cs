using System;
using System.Windows.Forms;

namespace Solvek.Gears.App
{
	public partial class Settings : Form
	{
		public Settings()
		{
			InitializeComponent();
		}

		public void SetConfig(Config config)
		{
			_useProxy.Checked = config.UseProxy;
			_proxyAddress.Text = config.ProxyAddress;
			_reqAuthentication.Checked = config.RequireAuthentication;
			_userName.Text = config.UserName;
			_password.Text = config.Password;
		}

		public Config GetConfig()
		{
			Config config = new Config();
			config.UseProxy = _useProxy.Checked;
			config.ProxyAddress = _proxyAddress.Text;
			config.RequireAuthentication = _reqAuthentication.Checked;
			config.UserName = _userName.Text;
			config.Password = _password.Text;

			return config;
		}

		private void menuItem1_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		private void menuItem2_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void _useProxy_CheckStateChanged(object sender, EventArgs e)
		{
			ActualizeEnabling();
		}

		private void _reqAuthorization_CheckStateChanged(object sender, EventArgs e)
		{
			this.ActualizeEnabling();
		}

		private void ActualizeEnabling()
		{
			_proxyAddress.Enabled = _useProxy.Checked;
			this._reqAuthentication.Enabled = _useProxy.Checked;
			_userName.Enabled = _useProxy.Checked && this._reqAuthentication.Checked;
			_password.Enabled = _useProxy.Checked && this._reqAuthentication.Checked;
		}
	}
}