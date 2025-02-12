using System;
using System.Reflection;

using TypeWrapping;

namespace BveTypes.ClassWrappers
{
    /// &lt;summary>
    /// シナリオファイルから読み込んだ情報にアクセスするための機能を提供します。
    /// &lt;/summary>
    public class ScenarioInfo : ClassWrapperBase
    {
        [InitializeClassWrapper]
        private static void Initialize(BveTypeSet bveTypes)
        {
            ClassMemberSet members = bveTypes.GetClassInfoOf&lt;ScenarioInfo>();

            PathGetMethod = members.GetSourcePropertyGetterOf(nameof(Path)).Source;
            PathSetMethod = members.GetSourcePropertySetterOf(nameof(Path)).Source;

            // ...
        }

        /// &lt;summary>
        /// オリジナル オブジェクトから &lt;see cref="ScenarioInfo"/> クラスの新しいインスタンスを初期化します。
        /// &lt;/summary>
        /// &lt;param name="src">ラップするオリジナル オブジェクト。&lt;/param>
        protected ScenarioInfo(object src) : base(src)
        {
        }

        private static MethodInfo PathGetMethod;
        private static MethodInfo PathSetMethod;
        /// &lt;summary>
        /// シナリオファイルのパスを取得・設定します。
        /// &lt;/summary>
        public string Path
        {
            get => PathGetMethod.Invoke(Src, null) as string;
            set => PathSetMethod.Invoke(Src, new object[] { value });
        }

        // ...
    }
}
