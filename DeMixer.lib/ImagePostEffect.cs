

using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace DeMixer.lib {	
	public abstract class ImagePostEffect {
		
		public virtual string PluginName {
			get { return Kernel.Translate(string.Format("{0} name", GetType().FullName)); }
		}
		
		public virtual string PluginTitle {
			get { return Kernel.Translate(string.Format("{0} title", GetType().FullName)); }
		}
		
		public void Init(IDeMixerKernel k) {
			kernel = k;
		}
		
		IDeMixerKernel kernel;
		protected IDeMixerKernel Kernel {
			get { return kernel; }	
		}
		
		/// <summary>
		/// Вызов диалога настроек эффекта
		/// </summary>
		public virtual void ShowDialog() {			
		}
		
		/// <summary>
		/// Применение фильтра к изображению
		/// </summary>
		/// <param name="img">
		/// Входное изображение <see cref="Image"/>
		/// </param>
		/// <returns>
		/// Выходное изображение после применения фильтра <see cref="Image"/>
		/// </returns>
		public virtual Image Execute(Image img) {
			return img;	
		}		
		/// <summary>
		/// Сохранение фильтра в поток
		/// </summary>
		/// <param name="stream">
		/// Поток для записи <see cref="BinaryWriter"/>
		/// </param>
		public virtual void Save(BinaryWriter stream) {
			
		}
		
		/// <summary>
		/// Чтение фильтра из потока
		/// </summary>
		/// <param name="stream">
		/// Поток для чтения <see cref="BinaryReader"/>
		/// </param>
		public virtual void Load(BinaryReader stream) {
			
		}	
		
		/// <summary>
		/// Создает копию текущего эффекта
		/// </summary>
		/// <returns>
		/// Копия эффекта <see cref="ImagePostEffect"/>
		/// </returns>
		public virtual  ImagePostEffect GetClone() {
			Type t = this.GetType();
			ConstructorInfo constr = t.GetConstructor(new Type[0]);
			return (ImagePostEffect)constr.Invoke(new object[0]);
		}
				
		public override string ToString () {
			return PluginName;
		}

	}
}
