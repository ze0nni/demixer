

using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Xml;

namespace DeMixer.lib {	
	public abstract class ImagePostEffect : DeMixerPlugin {		
		public override sealed string PluginType {
			get {
				return "effect";
			}
		}
		
		/// <summary>
		/// Вызов диалога настроек
		/// </summary>
		public virtual void ShowDialog(Gtk.Window parent) {			
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
		/// Создает копию текущего эффекта
		/// </summary>
		/// <returns>
		/// Копия эффекта <see cref="ImagePostEffect"/>
		/// </returns>
		public virtual  ImagePostEffect GetClone() {
			Type t = this.GetType();
			ConstructorInfo constr = t.GetConstructor(new Type[0]);
			ImagePostEffect pe = (ImagePostEffect)constr.Invoke(new object[0]);
			pe.Init(Kernel);
			return pe;
		}
				
		public override string ToString () {
			return PluginName;
		}

	}
}
