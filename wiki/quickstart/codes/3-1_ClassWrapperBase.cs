using System;

namespace BveTypes.ClassWrappers
{
    /// &lt;summary>
    /// すべてのクラスラッパーの基本クラスを表します。
    /// &lt;/summary>
    public abstract class ClassWrapperBase
    {
        /// &lt;summary>
        /// ラップされているオリジナル オブジェクトを取得します。
        /// &lt;/summary>
        public object Src { get; }

        /// &lt;summary>
        /// &lt;see cref="ClassWrapperBase"/> クラスの新しいインスタンスを初期化します。
        /// &lt;/summary>
        /// &lt;param name="src">ラップするオリジナル オブジェクト。&lt;/param>
        public ClassWrapperBase(object src)
        {
            Src = src;
        }
    }
}
