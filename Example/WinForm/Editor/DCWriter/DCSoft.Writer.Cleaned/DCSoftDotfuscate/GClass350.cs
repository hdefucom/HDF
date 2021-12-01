using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
    [ComVisible(false)]
    public class GClass350 : PropertyDescriptor
    {
        private GClass371 gclass371_0;

        public override string Name => gclass371_0.Name;

        public override string Category => gclass371_0.method_12();

        public override string Description => gclass371_0.method_14();

        public override bool IsBrowsable => gclass371_0.method_20();

        public override bool DesignTimeOnly => gclass371_0.method_16();

        public override string DisplayName => gclass371_0.method_18();

        public override Type ComponentType => gclass371_0.method_0();

        public override TypeConverter Converter => gclass371_0.method_6();

        public override bool IsLocalizable => gclass371_0.method_22();

        public override bool IsReadOnly => gclass371_0.method_10();

        public override Type PropertyType => gclass371_0.method_1();

        public GClass350(GClass371 gclass371_1, Attribute[] attribute_0) : base(gclass371_1.Name, attribute_0)
        {
            int num = 6;
            gclass371_0 = null;
            //base._002Ector(gclass371_1.Name, attribute_0);
            if (gclass371_1 == null)
            {
                throw new ArgumentNullException("property");
            }
            gclass371_0 = gclass371_1;
        }

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override object GetValue(object component)
        {
            return (component as XDependencyObject)?.method_1(gclass371_0);
        }

        public override void ResetValue(object component)
        {
            (component as XDependencyObject)?.vmethod_1(gclass371_0, gclass371_0.method_3());
        }

        public override void SetValue(object component, object value)
        {
            (component as XDependencyObject)?.vmethod_1(gclass371_0, value);
        }

        public override bool ShouldSerializeValue(object component)
        {
            XDependencyObject xDependencyObject = component as XDependencyObject;
            if (xDependencyObject != null)
            {
                object object_ = xDependencyObject.method_1(gclass371_0);
                if (gclass371_0.method_5(object_))
                {
                    return false;
                }
            }
            return true;
        }

        public override object GetEditor(Type editorBaseType)
        {
            if (gclass371_0.method_8() != null && editorBaseType.IsInstanceOfType(gclass371_0.method_8()))
            {
                return gclass371_0.method_8();
            }
            return null;
        }
    }
}
