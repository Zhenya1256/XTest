﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.34014
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hurricane.Properties {
    using System;
    
    
    /// <summary>
    ///   Eine stark typisierte Ressourcenklasse zum Suchen von lokalisierten Zeichenfolgen usw.
    /// </summary>
    // Diese Klasse wurde von der StronglyTypedResourceBuilder automatisch generiert
    // -Klasse über ein Tool wie ResGen oder Visual Studio automatisch generiert.
    // Um einen Member hinzuzufügen oder zu entfernen, bearbeiten Sie die .ResX-Datei und führen dann ResGen
    // mit der /str-Option erneut aus, oder Sie erstellen Ihr VS-Projekt neu.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Gibt die zwischengespeicherte ResourceManager-Instanz zurück, die von dieser Klasse verwendet wird.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Hurricane.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Überschreibt die CurrentUICulture-Eigenschaft des aktuellen Threads für alle
        ///   Ressourcenzuordnungen, die diese stark typisierte Ressourcenklasse verwenden.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die &lt;ResourceDictionary xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
        ///                    xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot; xmlns:system=&quot;clr-namespace:System;assembly=mscorlib&quot; xmlns:options=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation/options&quot;&gt;
        ///
        ///	&lt;Color x:Key=&quot;LightColor&quot;&gt;{LightColor}&lt;/Color&gt;
        ///    &lt;Color x:Key=&quot;BrightColor&quot;&gt;{BrightColor}&lt;/Color&gt;
        ///    &lt;Color x:Key=&quot;NormalColor&quot;&gt;{NormalColor}&lt;/Color&gt;
        ///    &lt;Color x:Key=&quot;DarkColor&quot;&gt;{DarkColor}&lt;/Color&gt;
        ///
        ///  [Rest der Zeichenfolge wurde abgeschnitten]&quot;; ähnelt.
        /// </summary>
        internal static string AccentColor {
            get {
                return ResourceManager.GetString("AccentColor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die &lt;ResourceDictionary xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
        ///                    xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
        ///                    xmlns:options=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation/options&quot;&gt;
        ///
        ///    &lt;Color x:Key=&quot;BlackColor&quot;&gt;{BlackColor}&lt;/Color&gt;
        ///    &lt;Color x:Key=&quot;WhiteColor&quot;&gt;{WhiteColor}&lt;/Color&gt;
        ///
        ///    &lt;Color x:Key=&quot;Gray1&quot;&gt;{Gray1}&lt;/Color&gt;
        ///    &lt;Color x:Key=&quot;Gray2&quot;&gt;{Gray2}&lt;/Color&gt;
        ///    &lt;Color x:Key=&quot;Gray7&quot;&gt;{Gray7}&lt;/Color&gt;
        ///    &lt;Color  [Rest der Zeichenfolge wurde abgeschnitten]&quot;; ähnelt.
        /// </summary>
        internal static string AppTheme {
            get {
                return ResourceManager.GetString("AppTheme", resourceCulture);
            }
        }
    }
}
